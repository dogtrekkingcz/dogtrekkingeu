using API.WebApiService.Entities;
using Mediator;

namespace API.WebApiService.Validators
{
    public sealed class GetEntriesByActionValidator : IPipelineBehavior<GetEntriesByActionRequest, GetEntriesByActionResponse>
    {
        public ValueTask<GetEntriesByActionResponse> Handle(GetEntriesByActionRequest request, CancellationToken cancellationToken, MessageHandlerDelegate<GetEntriesByActionRequest, GetEntriesByActionResponse> next)
        {
//            if (request is null || request.Id == default)
//                throw new ArgumentException("Invalid input");

            return next(request, cancellationToken);
        }
    }
}
