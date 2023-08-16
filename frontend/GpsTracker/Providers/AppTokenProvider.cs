using SharedLib.Providers;

namespace GpsTracker.Providers;

public class AppTokenProvider : ITokenProvider
{
    private string _token;

    public AppTokenProvider()
    {
    }

    public async Task<string> GetTokenAsync()
    {
        if (_token == null)
        {
            ;
        }

        return _token;
    }

    public void Set(string token)
    {
        _token = token;
    }
}