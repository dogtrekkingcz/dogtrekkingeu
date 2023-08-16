using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Authorization;
using SharedLib.Providers;

namespace GpsTracker.Providers;

public class ExternalAuthStateProvider : AuthenticationStateProvider
{
    private readonly ITokenProvider _tokenProvider;
    private ClaimsPrincipal currentUser = new ClaimsPrincipal(new ClaimsIdentity());

    public override Task<AuthenticationState> GetAuthenticationStateAsync() =>
        Task.FromResult(new AuthenticationState(currentUser));

    public ExternalAuthStateProvider(ITokenProvider tokenProvider)
    {
        _tokenProvider = tokenProvider;
    }

    public Task LogInAsync()
    {
        var loginTask = LogInAsyncCore();
        NotifyAuthenticationStateChanged(loginTask);

        return loginTask;

        async Task<AuthenticationState> LogInAsyncCore()
        {
            var user = await LoginWithExternalProviderAsync();
            currentUser = user;
            
            _tokenProvider.Set("");

            return new AuthenticationState(currentUser);
        }
    }

    private Task<ClaimsPrincipal> LoginWithExternalProviderAsync()
    {
        /*
            Provide OpenID/MSAL code to authenticate the user. See your identity
            provider's documentation for details.

            Return a new ClaimsPrincipal based on a new ClaimsIdentity.
        */
        var authenticatedUser = new ClaimsPrincipal(new ClaimsIdentity());

        return Task.FromResult(authenticatedUser);
    }

    public async Task LogoutAsync()
    {
        currentUser = new ClaimsPrincipal(new ClaimsIdentity());
        
        NotifyAuthenticationStateChanged(
            Task.FromResult(new AuthenticationState(currentUser)));
    }
}

public class AuthService
{
    public event Action<ClaimsPrincipal>? UserChanged;
    private ClaimsPrincipal? currentUser;

    public ClaimsPrincipal CurrentUser
    {
        get { return currentUser ?? new(); }
        set
        {
            currentUser = value;

            if (UserChanged is not null)
            {
                UserChanged(currentUser);
            }
        }
    }
}