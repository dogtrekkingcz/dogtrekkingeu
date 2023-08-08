namespace Mails.Services;

public interface ILocalizeService
{
    string Get(string key);

    public enum LanguageCode
    {
        English = 0,
        Czech = 1
    }
}