namespace PetsOnTrailApp.Providers;

public interface ITokenProvider
{
    public Task<string> GetTokenAsync();
}