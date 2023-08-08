using DogsOnTrail.Actions.Extensions;
using DogsOnTrail.Interfaces.Actions.Entities.Entries;
using DogsOnTrail.Interfaces.Actions.Entities.LiveUpdateSubscription;
using DogsOnTrail.Interfaces.Actions.Services;
using Mails.Builders.Emails;
using Mails.Entities;
using Mails.Entities.RegistrationToActionReceived;
using Mails.Services;
using MapsterMapper;
using Storage.Entities.Entries;
using Storage.Interfaces;

namespace DogsOnTrail.Actions.Services.EntriesManage
{
    internal class EntriesService : IEntriesService
    {
        private readonly IMapper _mapper;
        private readonly IEntriesRepositoryService _entriesRepositoryService;
        private readonly IActionsRepositoryService _actionsRepositoryService;
        private readonly ICurrentUserIdService _currentUserIdService;
        private readonly IMailSenderService _emailSenderService;
        private readonly ILiveUpdateSubscriptionService _liveUpdateSubscriptionService;

        public EntriesService(IMapper mapper, 
                                IEntriesRepositoryService entriesRepositoryService,
                                IActionsRepositoryService actionsRepositoryService,
                                ICurrentUserIdService currentUserIdService, 
                                IMailSenderService emailSenderService,
                                ILiveUpdateSubscriptionService liveUpdateSubscriptionService)
        {
            _mapper = mapper;
            _entriesRepositoryService = entriesRepositoryService;
            _actionsRepositoryService = actionsRepositoryService;
            _currentUserIdService = currentUserIdService;
            _emailSenderService = emailSenderService;
            _liveUpdateSubscriptionService = liveUpdateSubscriptionService;
        }

        public async Task<CreateEntryResponse> CreateEntryAsync(CreateEntryRequest request, CancellationToken cancellationToken)
        {
            Console.WriteLine($"Received createEntry request: '{request.Dump()}'");
            
            var createEntryInternalStorageRequest = _mapper.Map<CreateEntryInternalStorageRequest>(request);
            createEntryInternalStorageRequest.Id = Guid.NewGuid();
            createEntryInternalStorageRequest.Created = DateTimeOffset.Now;
            createEntryInternalStorageRequest.State = CreateEntryInternalStorageRequest.EntryState.Entered;
            
            var response = await _entriesRepositoryService.CreateEntryAsync(createEntryInternalStorageRequest, cancellationToken);

            var emailRequest = _mapper.Map<NewActionRegistrationEmailRequest>(request);

            ILocalizeService.LanguageCode languageCode;
            switch (request.LanguageCode)
            {
                case "en-US": languageCode = ILocalizeService.LanguageCode.English; break;
                case "cs-CZ": languageCode = ILocalizeService.LanguageCode.Czech; break;
                
                default: languageCode = ILocalizeService.LanguageCode.English; break;
            }

            var actionDetail = await _actionsRepositoryService.GetAsync(request.ActionId, cancellationToken);

            emailRequest.Action.Name = actionDetail.Name;
            emailRequest.Action.Term = new NewActionRegistrationEmailRequest.TermDto
            {
                From = actionDetail.Term.From,
                To = actionDetail.Term.To
            };

            var raceDetail = actionDetail.Races.First(race => race.Id == request.RaceId);
            emailRequest.Race = new NewActionRegistrationEmailRequest.RaceDto
            {
                Name = raceDetail.Name   
            };
            emailRequest.Category = new NewActionRegistrationEmailRequest.CategoryDto
            {
                Name = raceDetail.Categories.First(ctg => ctg.Id == request.CategoryId).Name
            };
            emailRequest.Action = new NewActionRegistrationEmailRequest.ActionDto
            {
                Email = actionDetail.ContactMail   
            };
            emailRequest.Racer = _mapper.Map<NewActionRegistrationEmailRequest.RacerDto>(createEntryInternalStorageRequest);
            emailRequest.Racer.Id = createEntryInternalStorageRequest.Id;
            emailRequest.Racer.Created = createEntryInternalStorageRequest.Created;

            foreach (var payment in raceDetail.Payments)
            {
                emailRequest.Payments[new NewActionRegistrationEmailRequest.TermDto { From = payment.From, To = payment.To }] =
                    new NewActionRegistrationEmailRequest.PaymentDto
                    {
                        BankAccount = payment.BankAccount,
                        From = payment.From,
                        To = payment.To,
                        Price = payment.Price,
                        Currency = payment.Currency
                    };
            }

            List<IEmailBuilder> mailBuilders = new();
            
            mailBuilders.Add(new Mails.Builders.Emails.Admin.NewActionRegistrationReceivedEmailBuilder(
                new LocalizeService(languageCode), emailRequest));
            mailBuilders.Add(new Mails.Builders.Emails.Participant.NewActionRegistrationReceivedEmailBuilder(
                new LocalizeService(languageCode), emailRequest));

            await _emailSenderService.SendAsync(mailBuilders, cancellationToken);

            await _liveUpdateSubscriptionService.SendAsync(new SendLiveUpdateRequest
            {
                FromUser = _currentUserIdService.GetUserId(),
                ToUser = _currentUserIdService.GetUserId(),
                Message = "New entry recieved",
                FromSection = Constants.LiveUpdateSections.Entries,
                ToSection = Constants.LiveUpdateSections.Entries
            }, cancellationToken);

            return new CreateEntryResponse
            {
                Id = response.Id
            };
        }

        public async Task<GetEntriesByActionResponse> GetEntriesByActionAsync(GetEntriesByActionRequest request, CancellationToken cancellationToken)
        {
            var getEntriesByActionInternalStorageRequest = _mapper.Map<GetEntriesByActionInternalStorageRequest>(request);

            var result = await _entriesRepositoryService.GetEntriesByActionAsync(getEntriesByActionInternalStorageRequest, cancellationToken);

            var response = _mapper.Map<GetEntriesByActionResponse>(result);

            return response;
        }
        
        public async Task<GetAllEntriesResponse> GetAllEntriesAsync(GetAllEntriesRequest request, CancellationToken cancellationToken)
        {
            var getAllEntriesInternalStorageRequest = _mapper.Map<GetAllEntriesInternalStorageRequest>(request);

            var result = await _entriesRepositoryService.GetAllEntriesAsync(getAllEntriesInternalStorageRequest, cancellationToken);

            var response = _mapper.Map<GetAllEntriesResponse>(result);

            return response;
        }

        public async Task DeleteEntryAsync(DeleteEntryRequest request, CancellationToken cancellationToken)
        {
            await _entriesRepositoryService.DeleteEntryAsync(new DeleteEntryInternalStorageRequest { Id = request.Id }, cancellationToken);
        }
    }
}
