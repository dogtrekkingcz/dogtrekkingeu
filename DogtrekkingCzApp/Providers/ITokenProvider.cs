namespace DogtrekkingCzApp.Providers;

public interface ITokenProvider
{
    public Task<string> GetTokenAsync();
}