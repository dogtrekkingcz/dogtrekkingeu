using GpsTracker.Services;
using IdentityModel.OidcClient;
using IdentityModel.OidcClient.Browser;
using IdentityModel.Client;
using SharedLib.Providers;

namespace GpsTracker.Auth0;

public class Auth0Client
{
    private readonly OidcClient oidcClient;
    private readonly ITokenProvider _tokenProvider;

    public Auth0Client(Auth0ClientOptions options, ITokenProvider tokenProvider)
    {
        _tokenProvider = tokenProvider;
        
        oidcClient = new OidcClient(new OidcClientOptions
        {
            Authority = options.Authority,
            ClientId = options.ClientId,
            Scope = options.Scope,
            RedirectUri = options.RedirectUri,
            Browser = options.Browser,
            Policy =
            {
                Discovery =
                {
                    RequireHttps = !options.Authority.Contains("10.0.2.2")  // in case of localhost - dont require HTTPS protocol
                }
            }
        });
    }

    public IdentityModel.OidcClient.Browser.IBrowser Browser
    {
        get
        {
            return oidcClient.Options.Browser;
        }
        set
        {
            oidcClient.Options.Browser = value;
        }
    }

    public async Task<LoginResult> LoginAsync()
    {
        var result = await oidcClient.LoginAsync();

        if (result.IsError == false)
        {
            _tokenProvider.Set(result.AccessToken);
            ServiceHelper.IsLoggedIn = true;
        }
        
        return result;
    }

    public async Task<BrowserResult> LogoutAsync()
    {
        var logoutParameters = new Dictionary<string, string>
        {
            {"client_id", oidcClient.Options.ClientId },
            {"returnTo", oidcClient.Options.RedirectUri }
        };

        var logoutRequest = new LogoutRequest();
        var endSessionUrl = new RequestUrl($"{oidcClient.Options.Authority}/v2/logout")
            .Create(new Parameters(logoutParameters));
        var browserOptions = new BrowserOptions(endSessionUrl, oidcClient.Options.RedirectUri)
        {
            Timeout = TimeSpan.FromSeconds(logoutRequest.BrowserTimeout),
            DisplayMode = logoutRequest.BrowserDisplayMode
        };

        var browserResult = await oidcClient.Options.Browser.InvokeAsync(browserOptions);

        return browserResult;
    }
}