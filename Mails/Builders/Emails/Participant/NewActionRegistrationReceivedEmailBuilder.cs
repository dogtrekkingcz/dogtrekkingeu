using Mails.Builders.Emails;
using Mails.Entities;
using Mails.Entities.RegistrationToActionReceived;
using Mails.Services;
using Microsoft.AspNetCore.Http;

namespace Mails.Builders.Emails.Participant;

public sealed class NewActionRegistrationReceivedEmailBuilder : IEmailBuilder
{
    private readonly ILocalizeService _localizeService;
    private NewActionRegistrationEmailRequest _request { get; }
        
    public List<IFormFile> Attachments { get; set; } = new();

    public string To => $@"{ _request.Racer.Email }";
    
    public string Subject => $@"[{_request.Action.Name} - {_request.Race.Name} - {_request.Category.Name}] {_localizeService.Get("NewActionRegistration.Emails.NewRegistrationReceived")}";
    
    public string Body => $@"
        <div>
            <h1>{_localizeService.Get("NewActionRegistration.Emails.InformNewRegistrationReceived")}</h1>
            <h4>{_localizeService.Get("NewActionRegistration.Emails.ReceivedInformations")}:</h4>
            <table>
                <tr>
                    <td><b>{_localizeService.Get("NewActionRegistration.Emails.NameSurname")}</b></td><td>{_request.Racer.Name}, {_request.Racer.Surname}</td>
                </tr>
                <tr>
                    <td><b>{_localizeService.Get("NewActionRegistration.Emails.ActionRaceCategory")}</b></td><td>{_request.Action.Name} - {_request.Race.Name} - {_request.Category.Name}</td>
                </tr>
                <tr>
                    <td><b>{_localizeService.Get("NewActionRegistration.Emails.Dogs")}</b></td>
                    <td>
                        <table>
                            <thead>
                                <th>{_localizeService.Get("NewActionRegistration.Emails.Dogs.Chip")}</th>
                                <th>{_localizeService.Get("NewActionRegistration.Emails.Dogs.Pedigree")}</th>
                                <th>{_localizeService.Get("NewActionRegistration.Emails.Dogs.Birthday")}</th>
                                <th>{_localizeService.Get("NewActionRegistration.Emails.Dogs.Name")}</th>
                            </thead>
                            <tbody>
                                {GenerateListOfPets()}
                            </tbody>
                        </table>
                    </td>
                </tr>
            </table>
            <hr />
            <h4>{_localizeService.Get("NewActionRegistration.Emails.NextActionWillBeAcceptingOfTheRegistrationByActionAdministratorPleaseWaitForAcceptanceEmail")}
            <hr />
            <h5>{_localizeService.Get("NewActionRegistration.Emails.InCaseOfUrgencyWriteUsAnEmailTo")}: <i><a href='mailto:{_request.Action.Email}'>{_request.Action.Email}</a></i></h5>
        </div>
    ";
    
    public NewActionRegistrationReceivedEmailBuilder(ILocalizeService localizeService, NewActionRegistrationEmailRequest request)
    {
        _localizeService = localizeService;
        _request = request;
    }

    private string GenerateListOfPets()
    {
        string ret = "";

        foreach (var pet in _request.Racer.Pets)
        {
            ret += $@"
                <tr>
                    <td>{pet.Chip}</td>
                    <td>{pet.Pedigree}</td>
                    <td>{pet.Birthday:yyyy-MM-dd}</td>
                    <td>{pet.Name}</td>
                </tr>
            ";
        }

        return ret;
    }
}