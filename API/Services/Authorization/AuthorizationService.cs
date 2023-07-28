using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using DogsOnTrail.Actions.Attributes;
using DogsOnTrail.Actions.Extensions;
using DogsOnTrail.Interfaces.Actions.Services;
using Storage.Entities.ActionRights;
using Storage.Interfaces;

namespace DogsOnTrail.Actions.Services.Authorization;

internal class AuthorizationService : IAuthorizationService
{
    private readonly IActionRightsRepositoryService _actionRightsRepositoryService;
    private readonly IAuthorizationRolesRepositoryService _authorizationRolesRepositoryService;
    private readonly ICurrentUserIdService _currentUserIdService;
    
    public AuthorizationService(IActionRightsRepositoryService actionRightsRepositoryService, IAuthorizationRolesRepositoryService authorizationRolesRepositoryService, ICurrentUserIdService currentUserIdService)
    {
        _actionRightsRepositoryService = actionRightsRepositoryService;
        _authorizationRolesRepositoryService = authorizationRolesRepositoryService;
        _currentUserIdService = currentUserIdService;
    }
    
    public async Task<bool> IsAuthorizedAsync(MethodInfo methodInfo, Guid actionId, CancellationToken cancellationToken)
    {
        var requiredRoles = methodInfo.GetCustomAttributes(true)
            .OfType<RequiredRolesAttribute>()
            .SelectMany(attr => attr.Roles).ToArray();
        
        Console.WriteLine($"Required roles for current action: '{requiredRoles?.Dump()}'");
        
        // TODO: fill it from db
        List<string> userRoles = new();

        var getAllRightsInternalStorageResponse = await _actionRightsRepositoryService.GetAllRightsAsync(new GetAllRightsInternalStorageRequest
        {
            UserId = _currentUserIdService.GetUserId()
        }, cancellationToken);

        userRoles = getAllRightsInternalStorageResponse.Rights
                        .Where(right => Guid.Empty == right.ActionId || (right.ActionId == actionId))
                        .SelectMany(right => right.Roles)
                        .ToList()
                    ?? new List<string>();

        Console.WriteLine($"Found roles for current user: '{userRoles?.Dump()}'");
        
        return userRoles.Intersect(requiredRoles).Any();
    }
}