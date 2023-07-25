using Mediator;

namespace API.WebApiService.Entities
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
