namespace SharedLib.Providers;

public interface ITokenProvider
{
    public Task<string> GetTokenAsync();

    public void Set(string token);
}