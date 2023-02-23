namespace DogtrekkingCzApp.Interfaces;

public interface ITokenProvider
{
    public Task<string> GetTokenAsync();
}