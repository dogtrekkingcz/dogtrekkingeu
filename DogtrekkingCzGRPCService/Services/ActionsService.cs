using Grpc.Core;
using Microsoft.Extensions.Logging;
using Protos;
using System;
using System.IO.IsolatedStorage;
using System.Threading.Tasks;
using DogtrekkingCz.Storage.Models;
using Google.Protobuf.Collections;
using MapsterMapper;
using Storage.Interfaces.Entities;
using Storage.Interfaces.Services;
using ActionRecord = Protos.ActionRecord;
using GetAllActionsRequest = Protos.GetAllActionsRequest;
using GetAllActionsResponse = Protos.GetAllActionsResponse;

namespace DogtrekkingCzGRPCService.Services;

public class ActionsService : Actions.ActionsBase
{
    private readonly ILogger<ActionsService> _logger;
    private readonly IMapper _mapper;
    private readonly IStorageService _storageService;

    public ActionsService(ILogger<ActionsService> logger, IMapper mapper, IStorageService storageService)
    {
        _logger = logger;
        _mapper = mapper;
        _storageService = storageService;
    }

    public async override Task<GetAllActionsResponse> getAllActions(GetAllActionsRequest request, ServerCallContext context)
    {
        var allActions = await _storageService.GetAllActionsAsync(
            new Storage.Interfaces.Entities.GetAllActionsRequest
            {
                Year = DateTime.Now.Year
            });

        if (allActions == null)
            return new GetAllActionsResponse
            {
                Actions = { }
            };
        
        var result = new Protos.GetAllActionsResponse
        {
            Actions = { _mapper.Map<RepeatedField<Protos.ActionRecord>>(allActions.Actions) }
        };

        return result;
    }

    public async override Task<CreateActionResponse> createAction(CreateActionRequest request, ServerCallContext context)
    {
        var result = await _storageService.AddActionAsync(
            new AddActionRequest
            {
                Name = request.Action.Name,
                Description = request.Action.Description,
                Owner = new AddActionRequest.OwnerRecord
                {
                    Id = request.Owner.Id,
                    Email = request.Owner.Email,
                    FirstName = request.Owner.FirstName,
                    FamilyName = request.Owner.FamilyName
                }
            });

        var response = _mapper.Map<CreateActionResponse>(result);

        return response;
    }
}