using DogsOnTrailWebApiService.Entities;
using Mediator;
using System.Threading;

namespace DogsOnTrailWebApiService.Validators
{
    public sealed class CreateEntryValidator : IPipelineBehavior<CreateEntryRequest, CreateEntryResponse>
    {
        public ValueTask<CreateEntryResponse> Handle(CreateEntryRequest request, CancellationToken cancellationToken, MessageHandlerDelegate<CreateEntryRequest, CreateEntryResponse> next)
        {
//            if (request is null || request.Id == default)
//                throw new ArgumentException("Invalid input");

            return next(request, cancellationToken);
        }
    }
}
