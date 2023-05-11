using Microsoft.AspNetCore.Components.WebAssembly.Authentication;

namespace DogsOnTrailApp.Providers;

public class AppTokenProvider : ITokenProvider
{
    private string _token;
    private IAccessTokenProvider _tokenProvider;

    public AppTokenProvider(IAccessTokenProvider tokenProvider)
    {
        _tokenProvider = tokenProvider;
    }

    public async Task<string> GetTokenAsync()
    {
        if (_token == null)
        {
            var tokenResult = await _tokenProvider.RequestAccessToken();

            if (tokenResult.TryGetToken(out var token))
            {
                _token = token.Value;
            }
        }

        return _token;
    }
}