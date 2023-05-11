using DogsOnTrail.Interfaces.Actions.Services;
using DogsOnTrailWebApiService.Entities;
using MapsterMapper;
using Mediator;

namespace DogsOnTrailWebApiService.RequestHandlers.Entries
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

            var getEntriesByActionRequest = mapper.Map<DogsOnTrail.Interfaces.Actions.Entities.Entries.GetEntriesByActionRequest>(request);

            var entries = await entriesService.GetEntriesByActionAsync(getEntriesByActionRequest, cancellationToken);

            return new ValueTask<GetEntriesByActionResponse>(new GetEntriesByActionResponse { Entries = entries.Entries }).Result;
        }
    }
}
