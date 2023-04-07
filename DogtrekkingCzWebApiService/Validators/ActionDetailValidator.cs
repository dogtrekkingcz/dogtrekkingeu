﻿using DogtrekkingCzWebApiService.Entities;
using Mediator;
using System.Threading;

namespace DogtrekkingCzWebApiService.Validators
{
    public sealed class ActionDetailValidator : IPipelineBehavior<ActionDetailRequest, ActionDetailResponse>
    {
        public ValueTask<ActionDetailResponse> Handle(ActionDetailRequest request, CancellationToken cancellationToken, MessageHandlerDelegate<ActionDetailRequest, ActionDetailResponse> next)
        {
//            if (request is null || request.Id == default)
//                throw new ArgumentException("Invalid input");

            return next(request, cancellationToken);
        }
    }
}
