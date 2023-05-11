using Mediator;

namespace DogsOnTrailWebApiService.Entities
{
    public sealed record ActionDetailRequest : IRequest<ActionDetailResponse>
    {
        private Guid _id { get; init; }

        public Guid Id { get { return _id; } }

        public ActionDetailRequest(Guid id) 
        {
            _id = id;
        }
    }
}
