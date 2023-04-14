using DogtrekkingCz.Entries.Interface.Services;
using DogtrekkingCzWebApiService.Entities;
using MapsterMapper;
using Mediator;

namespace DogtrekkingCzWebApiService.RequestHandlers.Entries
{
    public sealed class CreateEntryHandler : IRequestHandler<CreateEntryRequest, CreateEntryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public CreateEntryHandler(IMapper mapper, IServiceScopeFactory serviceScopeFactory)
        {
            _mapper = mapper;
            _serviceScopeFactory = serviceScopeFactory;
        }

        public async ValueTask<CreateEntryResponse> Handle(CreateEntryRequest request, CancellationToken cancellationToken)
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var mapper = scope.ServiceProvider.GetRequiredService<IMapper>();

            var entriesService = scope.ServiceProvider.GetRequiredService<IEntriesService>();

            var createEntryRequest = mapper.Map<DogtrekkingCz.Entries.Interface.Entities.CreateEntryRequest>(request);

            var newEntry = await entriesService.CreateEntryAsync(createEntryRequest, cancellationToken);

            var entry = _mapper.Map<CreateEntryResponse>(newEntry);
                
            return new ValueTask<CreateEntryResponse>(entry).Result;
        }
    }
}
