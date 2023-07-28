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
            .SelectMany(attr => attr.Roles)
            .ToArray();
        
        var getAllRightsInternalStorageResponse = await _actionRightsRepositoryService.GetAllRightsAsync(new GetAllRightsInternalStorageRequest
        {
            UserId = _currentUserIdService.GetUserId()
        }, cancellationToken);

        var userRoles = getAllRightsInternalStorageResponse.Rights
                        .Where(right => Guid.Empty == right.ActionId || (right.ActionId == actionId))
                        .SelectMany(right => right.Roles)
                        .ToList()
                    ?? new List<string>();

        return userRoles.Intersect(requiredRoles).Any();
    }
}