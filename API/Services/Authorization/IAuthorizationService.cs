using System.Reflection;
using System.Runtime.CompilerServices;

namespace PetsOnTrail.Actions.Services.Authorization;

internal interface IAuthorizationService
{
    public Task<bool> IsAuthorizedAsync(MethodInfo methodInfo, Guid actionId, CancellationToken cancellationToken);
}