namespace Mails.Services;

public class LocalizeService : ILocalizeService
{
    private Dictionary<ILocalizeService.LanguageCode, Dictionary<string, string>> _vocabularies { get; set; } = new();
    
    private ILocalizeService.LanguageCode _languageCode { get; set; }

    public LocalizeService(ILocalizeService.LanguageCode languageCode)
    {
        Load();
        _languageCode = languageCode;
    }
    
    public Dictionary<string, string> Get()
    {
        return _vocabularies[_languageCode];
    }

    private void Load()
    {
        _vocabularies[ILocalizeService.LanguageCode.Czech] = new Dictionary<string, string>();
        _vocabularies[ILocalizeService.LanguageCode.Czech]["NewActionRegistration.Emails.NameSurname"] = "Jméno, příjmení";
        _vocabularies[ILocalizeService.LanguageCode.Czech]["NewActionRegistration.Emails.ActionRaceCategory"] = "Akce, závod, kategorie";
        _vocabularies[ILocalizeService.LanguageCode.Czech]["NewActionRegistration.Emails.NewRegistrationReceived"] = "Nová registrace přijata";
        _vocabularies[ILocalizeService.LanguageCode.Czech]["NewActionRegistration.Emails.InformNewRegistrationReceived"] = "Potvrzujeme přijetí přihlášky, vyčkejte na akceptaci přihlášky s informacemi o startovném";
        _vocabularies[ILocalizeService.LanguageCode.Czech]["NewActionRegistration.Emails.Dogs"] = "Psi";
        _vocabularies[ILocalizeService.LanguageCode.Czech]["NewActionRegistration.Emails.Dogs.Chip"] = "Čip";
        _vocabularies[ILocalizeService.LanguageCode.Czech]["NewActionRegistration.Emails.Dogs.Pedigree"] = "Plemeno";
        _vocabularies[ILocalizeService.LanguageCode.Czech]["NewActionRegistration.Emails.Dogs.Birthday"] = "Datum narození";
        _vocabularies[ILocalizeService.LanguageCode.Czech]["NewActionRegistration.Emails.Dogs.Name"] = "Jméno";
        _vocabularies[ILocalizeService.LanguageCode.Czech][
                "NewActionRegistration.Emails.NextActionWillBeAcceptingOfTheRegistrationByActionAdministratorPleaseWaitForAcceptanceEmail"] =
            "Nyní bude následovat akceptování přihlášky administrátory akce, prosím vyčkejte na potvrzující email";
        _vocabularies[ILocalizeService.LanguageCode.Czech]["NewActionRegistration.Emails.ReceivedInformations"] = "Poskytnuté informace o příhlášce";
        _vocabularies[ILocalizeService.LanguageCode.Czech]["NewActionRegistration.Emails.InCaseOfUrgencyWriteUsAnEmailTo"] = "V případě potřeby nás kontaktujte na mail: ";

        _vocabularies[ILocalizeService.LanguageCode.English] = new Dictionary<string, string>();
        _vocabularies[ILocalizeService.LanguageCode.English]["NewActionRegistration.Emails.NameSurname"] = "Name, surname";
        _vocabularies[ILocalizeService.LanguageCode.English]["NewActionRegistration.Emails.ActionRaceCategory"] = "Action, race, category";
        _vocabularies[ILocalizeService.LanguageCode.English]["NewActionRegistration.Emails.NewRegistrationReceived"] = "New registration recieved";
        _vocabularies[ILocalizeService.LanguageCode.English]["NewActionRegistration.Emails.InformNewRegistrationReceived"] = "We are acknowledge we received the registration, please wait for acceptation of the registration and the payment information";
        _vocabularies[ILocalizeService.LanguageCode.English]["NewActionRegistration.Emails.Dogs"] = "Dogs";
        _vocabularies[ILocalizeService.LanguageCode.English]["NewActionRegistration.Emails.Dogs.Chip"] = "Chip";
        _vocabularies[ILocalizeService.LanguageCode.English]["NewActionRegistration.Emails.Dogs.Pedigree"] = "Pedigree";
        _vocabularies[ILocalizeService.LanguageCode.English]["NewActionRegistration.Emails.Dogs.Birthday"] = "Birthday";
        _vocabularies[ILocalizeService.LanguageCode.English]["NewActionRegistration.Emails.Dogs.Name"] = "Name";
        _vocabularies[ILocalizeService.LanguageCode.English][
                "NewActionRegistration.Emails.NextActionWillBeAcceptingOfTheRegistrationByActionAdministratorPleaseWaitForAcceptanceEmail"] =
            "Now the administrator of the action needs to accept your registration, please wait for the acceptation email";
        _vocabularies[ILocalizeService.LanguageCode.English]["NewActionRegistration.Emails.ReceivedInformations"] = "Received information";
        _vocabularies[ILocalizeService.LanguageCode.English]["NewActionRegistration.Emails.InCaseOfUrgencyWriteUsAnEmailTo"] = "In case of urgency - contact us at mail: ";
    }
}