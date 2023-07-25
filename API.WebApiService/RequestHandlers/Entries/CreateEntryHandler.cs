using API.WebApiService.Entities;
using DogsOnTrail.Interfaces.Actions.Services;
using MapsterMapper;
using Mediator;

namespace API.WebApiService.RequestHandlers.Entries
{
    public sealed class CreateEntryHandler : IRequestHandler<CreateEntryRequest, CreateEntryResponse>
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public CreateEntryHandler(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }

        public async ValueTask<CreateEntryResponse> Handle(CreateEntryRequest request, CancellationToken cancellationToken)
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var mapper = scope.ServiceProvider.GetRequiredService<IMapper>();

                var entriesService = scope.ServiceProvider.GetRequiredService<IEntriesService>();

                var createEntryRequest =
                    mapper.Map<DogsOnTrail.Interfaces.Actions.Entities.Entries.CreateEntryRequest>(request);

                var newEntry = await entriesService.CreateEntryAsync(createEntryRequest, cancellationToken);

                var entry = mapper.Map<CreateEntryResponse>(newEntry);
                
                return new ValueTask<CreateEntryResponse>(entry).Result;
            }
        }
    }
}
