using Grpc.Core;
using Microsoft.Extensions.Logging;
using Protos;
using System;
using System.IO.IsolatedStorage;
using System.Threading.Tasks;
using DogtrekkingCz.Storage.Models;
using Storage.Interfaces.Entities;
using Storage.Interfaces.Services;
using ActionRecord = Protos.ActionRecord;

namespace DogtrekkingCzGRPCService.Services;

public class ActionsService : Actions.ActionsBase
{
    private readonly ILogger<ActionsService> _logger;
    private readonly IStorageService _storageService;
    
    public ActionsService(ILogger<ActionsService> logger, IStorageService storageService)
    {
        _logger = logger;
        _storageService = storageService;
    }

    public async override Task<GetAllActionsResponse> getAllActions(GetAllActionsRequest request, ServerCallContext context)
    {
        await _storageService.AddActionAsync(new AddActionRequest { Name = "test" });
        
        GetAllActionsResponse result = new GetAllActionsResponse();
        result.Actions.Add(new ActionRecord { });

        return result;
    }

    public override Task<CreateActionResponse> createAction(CreateActionRequest request, ServerCallContext context)
    {
        ActionRecord action = new ActionRecord

        {
            BeachId = new Random().Next(),
            Name = request.Name,
            Condition = request.Condition
        };

        CreateActionResponse response = new CreateActionResponse
        {
            CreatedAction = action
        };

        return Task.FromResult(response);
    }
}