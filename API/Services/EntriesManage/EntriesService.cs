using DogsOnTrail.Interfaces.Actions.Entities.Entries;
using DogsOnTrail.Interfaces.Actions.Services;
using Mails.Entities;
using Mails.Services;
using Mails.Services.Emails;
using MapsterMapper;
using MongoDB.Bson;
using SharedCode.JwtToken;
using Storage.Entities.Entries;
using Storage.Interfaces;

namespace DogsOnTrail.Actions.Services.EntriesManage
{
    internal class EntriesService : IEntriesService
    {
        private readonly IMapper _mapper;
        private readonly IEntriesRepositoryService _entriesRepositoryService;
        private readonly IJwtTokenService _jwtTokenService;
        private readonly IMailSenderService _emailSenderService;

        public EntriesService(IMapper mapper, IEntriesRepositoryService entriesRepositoryService, IJwtTokenService jwtTokenService, IMailSenderService emailSenderService)
        {
            _mapper = mapper;
            _entriesRepositoryService = entriesRepositoryService;
            _jwtTokenService = jwtTokenService;
            _emailSenderService = emailSenderService;
        }

        public async Task<CreateEntryResponse> CreateEntryAsync(CreateEntryRequest request, CancellationToken cancellationToken)
        {
            var createEntryInternalStorageRequest = _mapper.Map<CreateEntryInternalStorageRequest>(request);
            var response = await _entriesRepositoryService.CreateEntryAsync(createEntryInternalStorageRequest, cancellationToken);

            var emailRequest = _mapper.Map<NewActionRegistrationEmailRequest>(request);

            ILocalizeService.LanguageCode languageCode = ILocalizeService.LanguageCode.English;
            switch (request.LanguageCode)
            {
                case "en-US": languageCode = ILocalizeService.LanguageCode.English; break;
                case "cs-CZ": languageCode = ILocalizeService.LanguageCode.Czech; break;
                
                default: languageCode = ILocalizeService.LanguageCode.English; break;
            }
            
            await _emailSenderService.SendAsync(
                new NewActionRegistrationReceivedEmailService(
                    new LocalizeService(languageCode), emailRequest),
                    cancellationToken
                );

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
