using DogtrekkingCz.Entries.Interface.Services;
using DogtrekkingCzWebApiService.Entities;
using MapsterMapper;
using Mediator;

namespace DogtrekkingCzWebApiService.RequestHandlers.Entries
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

            var getEntriesByActionRequest = mapper.Map<DogtrekkingCz.Entries.Interface.Entities.GetEntriesByActionRequest>(request);

            var entries = await entriesService.GetEntriesByAction(getEntriesByActionRequest, cancellationToken);

            return new ValueTask<GetEntriesByActionResponse>(new GetEntriesByActionResponse { Entries = entries.Entries }).Result;
        }
    }
}
