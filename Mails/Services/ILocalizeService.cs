namespace Mails.Services;

public interface ILocalizeService
{
    Dictionary<string, string> Get();

    public enum LanguageCode
    {
        English = 0,
        Czech = 1
    }
}