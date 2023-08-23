using DogsOnTrail.Actions.Attributes;
using DogsOnTrail.Actions.Exceptions;
using DogsOnTrail.Actions.Extensions;
using DogsOnTrail.Actions.Services.Authorization;
using DogsOnTrail.Interfaces.Actions.Entities.Actions;
using DogsOnTrail.Interfaces.Actions.Services;
using Mails.Builders.Emails;
using Mails.Entities.PaymentOfRegistrationReceived;
using Mails.Services;
using MapsterMapper;
using Storage.Entities.ActionRights;
using Storage.Entities.Actions;
using Storage.Entities.Entries;
using Storage.Interfaces;

namespace DogsOnTrail.Actions.Services.ActionsManage
{
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
            var addActionRequest = _mapper.Map<CreateActionInternalStorageRequest>(request);
            addActionRequest.Id = Guid.NewGuid();
            addActionRequest.UserId = _currentUserIdService.GetUserId();
            addActionRequest.Created = DateTimeOffset.Now;

            foreach (var race in addActionRequest.Races)
            {
                if (race.Id == default)
                    race.Id = Guid.NewGuid();

                foreach (var category in race.Categories)
                {
                    if (category.Id == default)
                        category.Id = Guid.NewGuid();
                }
            }

            var result = await _actionsRepositoryService.AddActionAsync(addActionRequest, cancellationToken);

            await _actionRightsRepositoryService.AddActionRightsAsync(new Storage.Entities.ActionRights.AddActionRightsInternalStorageRequest
            {
                Id = Guid.NewGuid().ToString(),
                ActionId = result.Id,
                UserId = _currentUserIdService.GetUserId(),
                Roles = new List<string> { Constants.Roles.OwnerOfAction.Id }
            }, cancellationToken);

            var response = _mapper.Map<CreateActionResponse>(result);

            return response;
        }

        [RequiredRoles(Constants.Roles.InternalAdministrator.Id, Constants.Roles.OwnerOfAction.Id)]
        public async Task<UpdateActionResponse> UpdateActionAsync(UpdateActionRequest request, CancellationToken cancellationToken)
        {
            if (!await _authorizationService.IsAuthorizedAsync(GetType().GetMethod(nameof(UpdateActionAsync)), request.Id, cancellationToken))
                throw new NotAuthorizedForThisActionException();
            
            var updateActionRequest = _mapper.Map<UpdateActionInternalStorageRequest>(request);
        
            var result = await _actionsRepositoryService.UpdateActionAsync(updateActionRequest, cancellationToken);

            var response = _mapper.Map<UpdateActionResponse>(result);

            return response;
        }
        
        [RequiredRoles(Constants.Roles.InternalAdministrator.Id, Constants.Roles.OwnerOfAction.Id)]
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

        [RequiredRoles(Constants.Roles.InternalAdministrator.Id)]
        public async Task<GetAllActionsResponse> GetAllActionsAsync(GetAllActionsRequest request, CancellationToken cancellationToken)
        {
            if (!await _authorizationService.IsAuthorizedAsync(GetType().GetMethod(nameof(GetAllActionsAsync)), Guid.Empty, cancellationToken))
                throw new NotAuthorizedForThisActionException();
            
            var allActions = await _actionsRepositoryService.GetAllActionsAsync(cancellationToken);

            var response = _mapper.Map<GetAllActionsResponse>(allActions);

            return response;
        }

        [RequiredRoles(Constants.Roles.InternalAdministrator.Id)]
        public async Task<GetAllActionsWithDetailsResponse> GetAllActionsWithDetailsAsync(GetAllActionsWithDetailsRequest request, CancellationToken cancellationToken)
        {
            if (!await _authorizationService.IsAuthorizedAsync(GetType().GetMethod(nameof(GetAllActionsWithDetailsAsync)), Guid.Empty, cancellationToken))
                throw new NotAuthorizedForThisActionException();
            
            var allActions = await _actionsRepositoryService.GetAllActionsAsync(cancellationToken);

            var response = _mapper.Map<GetAllActionsWithDetailsResponse>(allActions.Actions);

            return response;
        }

        [RequiredRoles(Constants.Roles.InternalAdministrator.Id, Constants.Roles.OwnerOfAction.Id)]
        public async Task<GetActionResponse> GetActionAsync(Guid id, CancellationToken cancellationToken)
        {
            if (!await _authorizationService.IsAuthorizedAsync(GetType().GetMethod(nameof(GetActionAsync)), id, cancellationToken))
                throw new NotAuthorizedForThisActionException();
            
            var result = await _actionsRepositoryService.GetAsync(id, cancellationToken);

            var response = _mapper.Map<GetActionResponse>(result);

            return response;
        }

        [RequiredRoles(Constants.Roles.InternalAdministrator.Id, Constants.Roles.OwnerOfAction.Id)]
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
                                MinimalAgeOfTheDogInDayes = r.Limits?.MinimalAgeOfTheDogInDayes ?? 0
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

        [RequiredRoles(Constants.Roles.InternalAdministrator.Id)]
        public async Task<GetSelectedActionsResponse> GetSelectedActionsAsync(GetSelectedActionsRequest request, CancellationToken cancellationToken)
        {
            if (!await _authorizationService.IsAuthorizedAsync(GetType().GetMethod(nameof(GetSelectedActionsAsync)), Guid.Empty, cancellationToken))
                throw new NotAuthorizedForThisActionException();
            
            var getSelectedActionsRequest = _mapper.Map<GetSelectedActionsInternalStorageRequest>(request);
            
            var result = await _actionsRepositoryService.GetSelectedActionsAsync(getSelectedActionsRequest, cancellationToken);

            return _mapper.Map<GetSelectedActionsResponse>(result);
        }

        [RequiredRoles(Constants.Roles.InternalAdministrator.Id, Constants.Roles.OwnerOfAction.Id)]
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

        [RequiredRoles(Constants.Roles.InternalAdministrator.Id, Constants.Roles.OwnerOfAction.Id)]
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

        [RequiredRoles(Constants.Roles.InternalAdministrator.Id, Constants.Roles.OwnerOfAction.Id)]
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
                    Name = registration.Name,
                    Surname = registration.Surname,
                    CompetitorId = registration.CompetitorId,
                    UserProfileId = registration.UserId,
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
    }
}
