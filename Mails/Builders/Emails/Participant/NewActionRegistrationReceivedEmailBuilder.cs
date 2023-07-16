using Mails.Builders.Emails;
using Mails.Entities;
using Mails.Services;
using Microsoft.AspNetCore.Http;

namespace Mails.Builders.Emails.Participant;

public sealed class NewActionRegistrationReceivedEmailBuilder : IEmailBuilder
{
    private NewActionRegistrationEmailRequest _request { get; }
        
    private Dictionary<string, string> _localize { get; set; }

    public List<IFormFile> Attachments { get; set; } = new();

    public string To => $@"{ _request.Racer.Email }";
    
    public string Subject => $@"[{_request.Action.Name} - {_request.Race.Name} - {_request.Category.Name}] {_localize["NewActionRegistration.Emails.NewRegistrationReceived"]}";
    
    public string Body => $@"
        <div>
            <h1>{_localize["NewActionRegistration.Emails.InformNewRegistrationReceived"]}</h1>
            <h4>{_localize["NewActionRegistration.Emails.ReceivedInformations"]}:</h4>
            <table>
                <tr>
                    <td><b>{_localize["NewActionRegistration.Emails.NameSurname"]}</b></td><td>{_request.Racer.Name}, {_request.Racer.Surname}</td>
                </tr>
                <tr>
                    <td><b>{_localize["NewActionRegistration.Emails.ActionRaceCategory"]}</b></td><td>{_request.Action.Name} - {_request.Race.Name} - {_request.Category.Name}</td>
                </tr>
                <tr>
                    <td><b>{_localize["NewActionRegistration.Emails.Dogs"]}</b></td>
                    <td>
                        <table>
                            <thead>
                                <th>{_localize["NewActionRegistration.Emails.Dogs.Chip"]}</th>
                                <th>{_localize["NewActionRegistration.Emails.Dogs.Pedigree"]}</th>
                                <th>{_localize["NewActionRegistration.Emails.Dogs.Birthday"]}</th>
                                <th>{_localize["NewActionRegistration.Emails.Dogs.Name"]}</th>
                            </thead>
                            <tbody>
                                {GenerateListOfDogs()}
                            </tbody>
                        </table>
                    </td>
                </tr>
            </table>
            <hr />
            <h4>{_localize["NewActionRegistration.Emails.NextActionWillBeAcceptingOfTheRegistrationByActionAdministratorPleaseWaitForAcceptanceEmail"]}
            <hr />
            <h5>{_localize["NewActionRegistration.Emails.InCaseOfUrgencyWriteUsAnEmailTo"]}: <i><a href='mailto:{_request.Action.Email}'>{_request.Action.Email}</a></i></h5>
        </div>
    ";
    
    public NewActionRegistrationReceivedEmailBuilder(ILocalizeService localizeService, NewActionRegistrationEmailRequest request)
    {
        _localize = localizeService.Get();
        _request = request;
    }

    private string GenerateListOfDogs()
    {
        string ret = "";

        foreach (var dog in _request.Racer.Dogs)
        {
            ret += $@"
                <tr>
                    <td>{dog.Chip}</td>
                    <td>{dog.Pedigree}</td>
                    <td>{dog.Birthday:yyyy-MM-dd}</td>
                    <td>{dog.Name}</td>
                </tr>
            ";
        }

        return ret;
    }
}