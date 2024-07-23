using PetsOnTrail.Actions.Attributes;
using PetsOnTrail.Actions.Exceptions;
using PetsOnTrail.Actions.Extensions;
using PetsOnTrail.Actions.Services.Authorization;
using PetsOnTrail.Interfaces.Actions.Entities.Actions;
using PetsOnTrail.Interfaces.Actions.Services;
using Mails.Builders.Emails;
using Mails.Entities.PaymentOfRegistrationReceived;
using Mails.Services;
using MapsterMapper;
using Storage.Entities.Actions;
using Storage.Entities.Entries;
using Storage.Interfaces;

namespace PetsOnTrail.Actions.Services.ActionsManage;

internal class ActionsService : IActionsService
{
    private readonly IMapper _mapper;
    private readonly IActionsRepositoryService _actionsRepositoryService;
    private readonly IActionRightsRepositoryService _actionRightsRepositoryService;
    private readonly IEntriesRepositoryService _entriesRepositoryService;
    private readonly IAuthorizationService _authorizationService;
    private readonly ICurrentUserIdService _currentUserIdService;
    private readonly ICheckpointsRepositoryService _checkpointsRepositoryService;
    private readonly IMailSenderService _emailSenderService;

    public ActionsService(IMapper mapper, 
        IActionsRepositoryService actionsRepositoryService, 
        IActionRightsRepositoryService actionRightsRepositoryService,
        IEntriesRepositoryService entriesRepositoryService,
        ICurrentUserIdService currentUserIdService,
        IAuthorizationService authorizationService,
        ICheckpointsRepositoryService checkpointsRepositoryService,
        IMailSenderService mailSenderService)
    {
        _mapper = mapper;
        _actionsRepositoryService = actionsRepositoryService;
        _actionRightsRepositoryService = actionRightsRepositoryService;
        _entriesRepositoryService = entriesRepositoryService;
        _authorizationService = authorizationService;
        _currentUserIdService = currentUserIdService;
        _checkpointsRepositoryService = checkpointsRepositoryService;
        _emailSenderService = mailSenderService;
    }

    public async Task<CreateActionResponse> CreateActionAsync(CreateActionRequest request, CancellationToken cancellationToken)
    {
        var addActionRequest = _mapper.Map<CreateActionInternalStorageRequest>(request) with
        {
            Id = Guid.NewGuid(),
            UserId = _currentUserIdService.GetUserId(),
            Created = DateTimeOffset.Now
        };            

        var result = await _actionsRepositoryService.AddActionAsync(addActionRequest, cancellationToken);

        await _actionRightsRepositoryService.AddActionRightsAsync(new Storage.Entities.ActionRights.AddActionRightsInternalStorageRequest
        {
            Id = Guid.NewGuid(),
            ActionId = result.Id,
            UserId = _currentUserIdService.GetUserId(),
            Roles = new List<Guid> { Constants.Roles.OwnerOfAction.GUID }
        }, cancellationToken);

        var response = _mapper.Map<CreateActionResponse>(result);

        return response;
    }

    [RequiredRoles(Constants.Roles.InternalAdministrator.ID, Constants.Roles.OwnerOfAction.ID)]
    public async Task<UpdateActionResponse> UpdateActionAsync(UpdateActionRequest request, CancellationToken cancellationToken)
    {
        if (!await _authorizationService.IsAuthorizedAsync(GetType().GetMethod(nameof(UpdateActionAsync)), request.Id, cancellationToken))
            throw new NotAuthorizedForThisActionException();
        
        var updateActionRequest = _mapper.Map<UpdateActionInternalStorageRequest>(request);
    
        var result = await _actionsRepositoryService.UpdateActionAsync(updateActionRequest, cancellationToken);

        var response = _mapper.Map<UpdateActionResponse>(result);

        return response;
    }
    
    [RequiredRoles(Constants.Roles.InternalAdministrator.ID, Constants.Roles.OwnerOfAction.ID)]
    public async Task<GetActionDetailResponse> GetActionDetailAsync(Guid id, CancellationToken cancellationToken)
    {
        if (!await _authorizationService.IsAuthorizedAsync(GetType().GetMethod(nameof(GetActionDetailAsync)), id, cancellationToken))
            throw new NotAuthorizedForThisActionException();
        
        var actionDetail = await _actionsRepositoryService.GetAsync(id, cancellationToken);

        foreach (var race in actionDetail.Races)
        {
            var price = race.Payments.First(payment => payment.From <= DateTimeOffset.Now && payment.To > DateTimeOffset.Now).Price;
            
            foreach (var category in race.Categories)
            {
                foreach (var racer in category.Racers)
                {
                    racer.RequestedPayments = new GetActionInternalStorageResponse.RequestedPaymentsDto
                    {
                        Items = new List<GetActionInternalStorageResponse.RequestedPaymentItem>
                        {
                            new GetActionInternalStorageResponse.RequestedPaymentItem
                            {
                                Name = "RegistrationFee",
                                Price = price
                            }
                        }
                    };
                    
                    foreach (var merch in racer.Merchandize)
                    {
                        racer.RequestedPayments.Items.Add(new GetActionInternalStorageResponse.RequestedPaymentItem
                        {
                            Name = merch.Name,
                            Price = merch.Price * merch.Count
                        });
                    }
                }
            }
        }

        return _mapper.Map<GetActionDetailResponse>(actionDetail);
    }

    [RequiredRoles(Constants.Roles.InternalAdministrator.ID)]
    public async Task<GetAllActionsResponse> GetAllActionsAsync(GetAllActionsRequest request, CancellationToken cancellationToken)
    {
        if (!await _authorizationService.IsAuthorizedAsync(GetType().GetMethod(nameof(GetAllActionsAsync)), Guid.Empty, cancellationToken))
            throw new NotAuthorizedForThisActionException();
        
        var allActions = await _actionsRepositoryService.GetAllActionsAsync(cancellationToken);

        var response = _mapper.Map<GetAllActionsResponse>(allActions);

        return response;
    }

    [RequiredRoles(Constants.Roles.InternalAdministrator.ID)]
    public async Task<GetAllActionsWithDetailsResponse> GetAllActionsWithDetailsAsync(GetAllActionsWithDetailsRequest request, CancellationToken cancellationToken)
    {
        if (!await _authorizationService.IsAuthorizedAsync(GetType().GetMethod(nameof(GetAllActionsWithDetailsAsync)), Guid.Empty, cancellationToken))
            throw new NotAuthorizedForThisActionException();
        
        var allActions = await _actionsRepositoryService.GetAllActionsAsync(cancellationToken);

        var response = _mapper.Map<GetAllActionsWithDetailsResponse>(allActions.Actions);

        return response;
    }

    [RequiredRoles(Constants.Roles.InternalAdministrator.ID, Constants.Roles.OwnerOfAction.ID)]
    public async Task<GetActionResponse> GetActionAsync(Guid id, CancellationToken cancellationToken)
    {
        var result = await _actionsRepositoryService.GetAsync(id, cancellationToken);

        // if user is not authorized, return only basic/public informations
        if (!await _authorizationService.IsAuthorizedAsync(GetType().GetMethod(nameof(GetActionAsync)), id, cancellationToken))
            return new GetActionResponse
            {
                Id = result.Id,
                TypeId = result.TypeId,
                Name = result.Name,
                Description = result.Description,
                Term = new GetActionResponse.TermDto
                {
                    From = result.Term.From,
                    To = result.Term.To
                },
                Address = new GetActionResponse.AddressDto
                {
                    Country = result.Address.Country,
                    City = result.Address.City,
                    Street = result.Address.Street,
                    Position = new GetActionResponse.LatLngDto
                    {
                        Latitude = result.Address.Position.Latitude,
                        Longitude = result.Address.Position.Longitude
                    }
                }
            };

        var response = _mapper.Map<GetActionResponse>(result);

        return response;
    }

    [RequiredRoles(Constants.Roles.InternalAdministrator.ID, Constants.Roles.OwnerOfAction.ID)]
    public async Task DeleteActionAsync(Guid id, CancellationToken cancellationToken)
    {
        if (!await _authorizationService.IsAuthorizedAsync(GetType().GetMethod(nameof(DeleteActionAsync)), id, cancellationToken))
            throw new NotAuthorizedForThisActionException();
        
        await _actionsRepositoryService.DeleteActionAsync(id, cancellationToken);
    }

    public async Task<GetActionEntrySettingsResponse> GetActionEntrySettings(Guid id, CancellationToken cancellationToken)
    {
        var result = await _actionsRepositoryService.GetAsync(id, cancellationToken);

        var response = new GetActionEntrySettingsResponse
        {
            Id = result.Id,
            Name = result.Name,
            Races = result.Races.Select(r => 
                    new GetActionEntrySettingsResponse.RaceDto
                    {
                        Id = r.Id,
                        Name = r.Name,
                        Start = r.Begin,
                        Limits = new GetActionEntrySettingsResponse.RaceLimits
                        {
                            MinimalAgeOfRacerInDayes = r.Limits?.MinimalAgeOfRacerInDayes ?? 0,
                            MinimalAgeOfThePetInDayes = r.Limits?.MinimalAgeOfThePetInDayes ?? 0
                        }
                    })
                    .ToList(),
            Categories = result.Races.SelectMany(r => r.Categories.Select(ctg =>
                new GetActionEntrySettingsResponse.CategoryDto
                {
                    Id = ctg.Id,
                    Name = ctg.Name,
                    RaceId = r.Id
                }))
                .ToList()
        };

        return response;
    }

    [RequiredRoles(Constants.Roles.InternalAdministrator.ID)]
    public async Task<GetSelectedActionsResponse> GetSelectedActionsAsync(GetSelectedActionsRequest request, CancellationToken cancellationToken)
    {
        if (!await _authorizationService.IsAuthorizedAsync(GetType().GetMethod(nameof(GetSelectedActionsAsync)), Guid.Empty, cancellationToken))
            throw new NotAuthorizedForThisActionException();
        
        var getSelectedActionsRequest = _mapper.Map<GetSelectedActionsInternalStorageRequest>(request);
        
        var result = await _actionsRepositoryService.GetSelectedActionsAsync(getSelectedActionsRequest, cancellationToken);

        return _mapper.Map<GetSelectedActionsResponse>(result);
    }

    [RequiredRoles(Constants.Roles.InternalAdministrator.ID, Constants.Roles.OwnerOfAction.ID)]
    public async Task AcceptRegistrationAsync(Guid registrationId, CancellationToken cancellationToken)
    {
        var registration = await _entriesRepositoryService.GetAsync(registrationId, cancellationToken);
        
        if (!await _authorizationService.IsAuthorizedAsync(GetType().GetMethod(nameof(AcceptRegistrationAsync)), registration.ActionId, cancellationToken))
            throw new NotAuthorizedForThisActionException();

        var action = await _actionsRepositoryService.GetAsync(registration.ActionId, cancellationToken);

        var actionUpdateRequest = _mapper.Map<UpdateActionInternalStorageRequest>(action);
        var race = actionUpdateRequest.Races.First(race => race.Id == registration.RaceId);
        var category = race.Categories.First(category => category.Id == registration.CategoryId);

        var requestedPayments = new List<UpdateActionInternalStorageRequest.RequestedPaymentItem>();
        foreach (var merch in registration.Merchandize)
        {
            requestedPayments.Add(new UpdateActionInternalStorageRequest.RequestedPaymentItem
            {
                Name = merch.Name,
                Price = merch.Price,
                Currency = merch.Currency
            });
        }
        
        var racer = _mapper.Map<UpdateActionInternalStorageRequest.RacerDto>(registration) with
        {
            PassedCheckpoints = new List<UpdateActionInternalStorageRequest.PassedCheckpointDto>(),
            AcceptedDate = DateTime.Now,
            Accepted = true,
            PayedDate = null,
            Payed = false,
            RequestedPayments = new UpdateActionInternalStorageRequest.RequestedPaymentsDto
            {
                VariableNumber = registration.Phone.Substring(registration.Phone.Length - 9, 9),
                Items = requestedPayments
            }
        };
        category.Racers.Add(racer);

        await _actionsRepositoryService.UpdateActionAsync(
            actionUpdateRequest,
            cancellationToken);

        var updateEntryRequest = _mapper.Map<UpdateEntryInternalStorageRequest>(registration);
        updateEntryRequest.Accepted = true;
        updateEntryRequest.AcceptedDate = DateTime.Now;
        updateEntryRequest.State = UpdateEntryInternalStorageRequest.EntryState.Accepted;

        await _entriesRepositoryService.UpdateEntryAsync(updateEntryRequest, cancellationToken);
    }

    [RequiredRoles(Constants.Roles.InternalAdministrator.ID, Constants.Roles.OwnerOfAction.ID)]
    public async Task AcceptCheckpointAsync(AcceptCheckpointRequest request, CancellationToken cancellationToken)
    {
        var checkpoint = await _checkpointsRepositoryService.GetAsync(request.Id, cancellationToken);
        
        if (!await _authorizationService.IsAuthorizedAsync(GetType().GetMethod(nameof(AcceptCheckpointAsync)), checkpoint.ActionId, cancellationToken))
            throw new NotAuthorizedForThisActionException();

        var action = await _actionsRepositoryService.GetAsync(checkpoint.ActionId, cancellationToken);

        var racer = action.Races
            .SelectMany(race => race.Categories
                .SelectMany(ctg => ctg.Racers))
            .FirstOrDefault(racer => racer.CheckpointData == checkpoint.Data);

        if (racer != null)
        {
            racer.PassedCheckpoints.Add(_mapper.Map<GetActionInternalStorageResponse.PassedCheckpointDto>(checkpoint));
        }
    }

    public async Task DenyRegistrationAsync(Guid registrationId, string reason, CancellationToken cancellationToken)
    {
        
    }

    [RequiredRoles(Constants.Roles.InternalAdministrator.ID, Constants.Roles.OwnerOfAction.ID)]
    public async Task AcceptPaymentAsync(AcceptPaymentRequest request, CancellationToken cancellationToken)
    {
        if (!await _authorizationService.IsAuthorizedAsync(GetType().GetMethod(nameof(AcceptPaymentAsync)), request.ActionId, cancellationToken))
            throw new NotAuthorizedForThisActionException();
        
        var action = await _actionsRepositoryService.GetAsync(request.ActionId, cancellationToken);

        var updateActionRequest = _mapper.Map<UpdateActionInternalStorageRequest>(action);
        
        var updateRacer = updateActionRequest.Races
            .SelectMany(r => r.Categories)
            .SelectMany(c => c.Racers)
            .First(racer => racer.Id == request.Id); 
        updateRacer.Payments.Add(new UpdateActionInternalStorageRequest.PaymentDto
                {
                    Date = DateTimeOffset.Now,
                    Amount = request.Amount,
                    Currency = request.Currency,
                    Note = request.Note,
                    BankAccount = request.BankAccount
                });
        updateRacer.Payed = true;
        updateRacer.PayedDate = DateTimeOffset.Now;

        await _actionsRepositoryService.UpdateActionAsync(updateActionRequest, cancellationToken);

        var registration = await _entriesRepositoryService.GetAsync(request.Id, cancellationToken);
        var updateRegistrationRequest = _mapper.Map<UpdateEntryInternalStorageRequest>(registration);
        updateRegistrationRequest.State = UpdateEntryInternalStorageRequest.EntryState.Paid;

        await _entriesRepositoryService.UpdateEntryAsync(updateRegistrationRequest, cancellationToken);


        var racer = action.Races.SelectMany(r => r.Categories.SelectMany(ctg => ctg.Racers))
            .FirstOrDefault(racer => racer.Id == registration.Id);
        NewActionRegistrationPaymentEmailRequest emailRequest = new()
        {
            Racer = new NewActionRegistrationPaymentEmailRequest.RacerDto
            {
                LanguageCode = registration.LanguageCode,
                Id = registration.Id,
                FirstName = registration.FirstName,
                LastName = registration.LastName,
                CompetitorId = registration.CompetitorId,
                UserId = registration.UserId,
                Created = registration.Created
            },
            Amount = request.Amount,
            Currency = request.Currency,
            Action = new NewActionRegistrationPaymentEmailRequest.ActionDto
            {
                Email = action.ContactMail,
                Name = action.Name
            },
            ReceivedPayments = racer.Payments.Select(payment => new  NewActionRegistrationPaymentEmailRequest.ReceivedPaymentDto
            {
                Received = payment.Date,
                Amount = payment.Amount,
                Currency = payment.Currency
            })
                .ToList(),
            Payments = new Dictionary<NewActionRegistrationPaymentEmailRequest.TermDto, NewActionRegistrationPaymentEmailRequest.PaymentDto>()
        };

        ILocalizeService.LanguageCode languageCode;
        switch (registration.LanguageCode)
        {
            case "en-US": languageCode = ILocalizeService.LanguageCode.English; break;
            case "cs-CZ": languageCode = ILocalizeService.LanguageCode.Czech; break;
            
            default: languageCode = ILocalizeService.LanguageCode.English; break;
        }
        
        List<IEmailBuilder> mailBuilders = new();
        
        mailBuilders.Add(new Mails.Builders.Emails.Admin.NewActionRegistrationPaymentReceivedEmailBuilder(
            new LocalizeService(languageCode), emailRequest));
        mailBuilders.Add(new Mails.Builders.Emails.Participant.NewActionRegistrationPaymentReceivedEmailBuilder(
            new LocalizeService(languageCode), emailRequest));

        await _emailSenderService.SendAsync(mailBuilders, cancellationToken);
    }

    public async Task<GetRacesForActionResponse> GetRacesForActionAsync(GetRacesForActionRequest request, CancellationToken cancellationToken)
    {
        var action = await _actionsRepositoryService.GetAsync(request.ActionId, cancellationToken);

        return _mapper.Map<GetRacesForActionResponse>(action);
    }

    public async Task<GetResultsForActionResponse> GetResultsForActionAsync(GetResultsForActionRequest request, CancellationToken cancellationToken)
    {
        var action = await _actionsRepositoryService.GetAsync(request.ActionId, cancellationToken);

        Console.WriteLine($"{nameof(GetResultsForActionAsync)}: {action.Dump()}");
        return _mapper.Map<GetResultsForActionResponse>(action);
    }

    public async Task<GetPublicActionsListResponse> GetPublicActionsListAsync(GetPublicActionsListRequest request, CancellationToken cancellationToken)
    {
        var actions = await _actionsRepositoryService.GetAllActionsAsync(cancellationToken);

        return _mapper.Map<GetPublicActionsListResponse>(actions);
    }

    public async Task<GetSelectedPublicActionsListResponse> GetSelectedPublicActionsListAsync(GetSelectedPublicActionsListRequest request, CancellationToken cancellationToken)
    {
        var actions = await _actionsRepositoryService.GetSelectedActionsAsync(new GetSelectedActionsInternalStorageRequest
        {
            Ids = request.Ids
        }, cancellationToken);
        
        return _mapper.Map<GetSelectedPublicActionsListResponse>(actions);
    }

    public async Task<GetSimpleActionsListByTypeResponse> GetSimpleActionsListByTypeAsync(IList<Guid> typeIds, CancellationToken cancellationToken)
    {
        var actions = await _actionsRepositoryService.GetSimpleActionsListByTypeAsync(typeIds, cancellationToken);

        return _mapper.Map<GetSimpleActionsListByTypeResponse>(actions);
    }

    public async Task<StartNowResponse> StartNowAsync(StartNowRequest request, CancellationToken cancellationToken)
    {
        var action = await _actionsRepositoryService.GetAsync(request.ActionId, cancellationToken);
        var race = action.Races.FirstOrDefault(race => race.Id == request.RaceId);
        var category = race.Categories.FirstOrDefault(category => category.Id == request.CategoryId);
        var racer = category.Racers.FirstOrDefault(racer => racer.Id == request.RacerId);
        racer.Start = request.Time;
        racer.State = racer.Finish != null ? GetActionInternalStorageResponse.RaceState.Finished : GetActionInternalStorageResponse.RaceState.Started;
        
        await _actionsRepositoryService.UpdateActionAsync(_mapper.Map<UpdateActionInternalStorageRequest>(action), cancellationToken);

        return new StartNowResponse();
    }

    public async Task<FinishNowResponse> FinishNowAsync(FinishNowRequest request, CancellationToken cancellationToken)
    {
        var action = await _actionsRepositoryService.GetAsync(request.ActionId, cancellationToken);
        var race = action.Races.FirstOrDefault(race => race.Id == request.RaceId);
        var category = race.Categories.FirstOrDefault(category => category.Id == request.CategoryId);
        var racer = category.Racers.FirstOrDefault(racer => racer.Id == request.RacerId);
        racer.Finish = request.Time;
        racer.State = racer.Start != null ? GetActionInternalStorageResponse.RaceState.Finished : GetActionInternalStorageResponse.RaceState.NotValid;

        await _actionsRepositoryService.UpdateActionAsync(_mapper.Map<UpdateActionInternalStorageRequest>(action), cancellationToken);

        return new FinishNowResponse();
    }

    public async Task<DeleteStartResponse> DeleteStartAsync(DeleteStartRequest request, CancellationToken cancellationToken)
    {
        var action = await _actionsRepositoryService.GetAsync(request.ActionId, cancellationToken);
        var race = action.Races.FirstOrDefault(race => race.Id == request.RaceId);
        var category = race.Categories.FirstOrDefault(category => category.Id == request.CategoryId);
        var racer = category.Racers.FirstOrDefault(racer => racer.Id == request.RacerId);
        racer.Start = null;
        racer.State = GetActionInternalStorageResponse.RaceState.NotValid;

        await _actionsRepositoryService.UpdateActionAsync(_mapper.Map<UpdateActionInternalStorageRequest>(action), cancellationToken);

        return new DeleteStartResponse();
    }

    public async Task<DeleteFinishResponse> DeleteFinishAsync(DeleteFinishRequest request, CancellationToken cancellationToken)
    {
        var action = await _actionsRepositoryService.GetAsync(request.ActionId, cancellationToken);
        var race = action.Races.FirstOrDefault(race => race.Id == request.RaceId);
        var category = race.Categories.FirstOrDefault(category => category.Id == request.CategoryId);
        var racer = category.Racers.FirstOrDefault(racer => racer.Id == request.RacerId);
        racer.Finish = null;
        racer.State = racer.Start == null ? GetActionInternalStorageResponse.RaceState.NotValid : GetActionInternalStorageResponse.RaceState.Started;

        await _actionsRepositoryService.UpdateActionAsync(_mapper.Map<UpdateActionInternalStorageRequest>(action), cancellationToken);

        return new DeleteFinishResponse();
    }

    public async Task<DnsResponse> DnsAsync(DnsRequest request, CancellationToken cancellationToken)
    {
        var action = await _actionsRepositoryService.GetAsync(request.ActionId, cancellationToken);
        var race = action.Races.FirstOrDefault(race => race.Id == request.RaceId);
        var category = race.Categories.FirstOrDefault(category => category.Id == request.CategoryId);
        var racer = category.Racers.FirstOrDefault(racer => racer.Id == request.RacerId);
        racer.State = GetActionInternalStorageResponse.RaceState.NotStarted;

        await _actionsRepositoryService.UpdateActionAsync(_mapper.Map<UpdateActionInternalStorageRequest>(action), cancellationToken);

        return new DnsResponse();
    }

    public async Task<DsqResponse> DsqAsync(DsqRequest request, CancellationToken cancellationToken)
    {
        var action = await _actionsRepositoryService.GetAsync(request.ActionId, cancellationToken);
        var race = action.Races.FirstOrDefault(race => race.Id == request.RaceId);
        var category = race.Categories.FirstOrDefault(category => category.Id == request.CategoryId);
        var racer = category.Racers.FirstOrDefault(racer => racer.Id == request.RacerId);
        racer.State = GetActionInternalStorageResponse.RaceState.Disqualified;

        await _actionsRepositoryService.UpdateActionAsync(_mapper.Map<UpdateActionInternalStorageRequest>(action), cancellationToken);

        return new DsqResponse();
    }

    public async Task<DnfResponse> DnfAsync(DnfRequest request, CancellationToken cancellationToken)
    {
        var action = await _actionsRepositoryService.GetAsync(request.ActionId, cancellationToken);
        var race = action.Races.FirstOrDefault(race => race.Id == request.RaceId);
        var category = race.Categories.FirstOrDefault(category => category.Id == request.CategoryId);
        var racer = category.Racers.FirstOrDefault(racer => racer.Id == request.RacerId);
        racer.State = GetActionInternalStorageResponse.RaceState.DidNotFinished;

        await _actionsRepositoryService.UpdateActionAsync(_mapper.Map<UpdateActionInternalStorageRequest>(action), cancellationToken);

        return new DnfResponse();
    }

    public async Task<ResetStatesResponse> ResetStatesAsync(ResetStatesRequest request, CancellationToken cancellationToken)
    {
        var action = await _actionsRepositoryService.GetAsync(request.ActionId, cancellationToken);
        var race = action.Races.FirstOrDefault(race => race.Id == request.RaceId);
        var category = race.Categories.FirstOrDefault(category => category.Id == request.CategoryId);
        var racer = category.Racers.FirstOrDefault(racer => racer.Id == request.RacerId);
        
        if (racer.Start != null && racer.Finish != null)
            racer.State = GetActionInternalStorageResponse.RaceState.Finished;
        
        else if (racer.Start != null && racer.Finish == null)
            racer.State = GetActionInternalStorageResponse.RaceState.Started;

        else
            racer.State = GetActionInternalStorageResponse.RaceState.NotValid;


        await _actionsRepositoryService.UpdateActionAsync(_mapper.Map<UpdateActionInternalStorageRequest>(action), cancellationToken);

        return new ResetStatesResponse();
    }

    public async Task<AddNewResultResponse> AddNewResultAsync(AddNewResultRequest request, CancellationToken cancellationToken)
    {
        var action = await _actionsRepositoryService.GetAsync(request.ActionId, cancellationToken);
        var race = action.Races.FirstOrDefault(race => race.Id == request.RaceId);
        var category = race.Categories.FirstOrDefault(category => category.Id == request.CategoryId);

        var racer = _mapper.Map<GetActionInternalStorageResponse.RacerDto>(request);

        // in case of update - replace it with new one
        if (category.Racers.Any(r => r.Id == request.Id))
            category.Racers.Remove(category.Racers.First(r => r.Id == request.Id));

        category.Racers.Add(_mapper.Map<GetActionInternalStorageResponse.RacerDto>(request));


        await _actionsRepositoryService.UpdateActionAsync(_mapper.Map<UpdateActionInternalStorageRequest>(action), cancellationToken);

        return new AddNewResultResponse();
    }

    public async Task<GetActionsResponse> GetActionsAsync(GetActionsRequest request, CancellationToken cancellationToken) {
        var allActions = await _actionsRepositoryService.GetAllActionsAsync(cancellationToken);

        IEnumerable<GetAllActionsInternalStorageResponse.ActionDto> filteredByType = null;
        
        if (request.TypeIds == null || request.TypeIds.Count() == 0)
            filteredByType = allActions.Actions;
        else
            filteredByType = allActions.Actions.Where(a => request.TypeIds.Contains(a.TypeId));

        var result = new GetActionsResponse
        {
            Actions = filteredByType.Select(action => new GetActionsResponse.ActionDto
            {
                Id = action.Id,
                TypeId = action.TypeId,
                Name = action.Name,
                Description = action.Description,
                From = action.Term.From,
                To = action.Term.To,
                Country = action.Address.Country,
                Province = string.Empty,
                City = action.Address.City,
                PostalCode = string.Empty,
                Address = action.Address.Street,
                Latitude = action.Address.Position.Latitude,
                Longitude = action.Address.Position.Longitude
            })
        };
    
        return result;
    }
}
