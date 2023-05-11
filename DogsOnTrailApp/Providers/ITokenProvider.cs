namespace DogsOnTrailApp.Providers;

public interface ITokenProvider
{
    public Task<string> GetTokenAsync();
}