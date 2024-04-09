using API.WebApiService.Entities;
using PetsOnTrail.Interfaces.Actions.Services;
using MapsterMapper;
using Mediator;

namespace API.WebApiService.RequestHandlers.Entries
{
    public sealed class GetEntriesByActionHandler : IRequestHandler<GetEntriesByActionRequest, GetEntriesByActionResponse>
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public GetEntriesByActionHandler(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }

        public async ValueTask<GetEntriesByActionResponse> Handle(GetEntriesByActionRequest request, CancellationToken cancellationToken)
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var mapper = scope.ServiceProvider.GetRequiredService<IMapper>();

            var entriesService = scope.ServiceProvider.GetRequiredService<IEntriesService>();

            var getEntriesByActionRequest = mapper.Map<PetsOnTrail.Interfaces.Actions.Entities.Entries.GetEntriesByActionRequest>(request);

            var entries = await entriesService.GetEntriesByActionAsync(getEntriesByActionRequest, cancellationToken);

            var response = mapper.Map<GetEntriesByActionResponse>(entries);
            
            return new ValueTask<GetEntriesByActionResponse>(response).Result;
        }
    }
}
