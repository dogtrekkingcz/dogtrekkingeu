using System.Runtime.CompilerServices;

namespace DogsOnTrail.Actions.Services.Authorization;

internal interface IAuthorizationService
{
    public Task<bool> IsAuthorizedAsync(Guid actionId, CancellationToken cancellationToken, [CallerMemberName] string callerName = "");
}