using Mails.Entities.PaymentOfRegistrationReceived;
using Mails.Services;
using Microsoft.AspNetCore.Http;

namespace Mails.Builders.Emails.Participant;

public sealed class NewActionRegistrationPaymentReceivedEmailBuilder : IEmailBuilder
{
    private NewActionRegistrationPaymentEmailRequest _request { get; }
        
    private Dictionary<string, string> _localize { get; set; }

    public List<IFormFile> Attachments { get; set; } = new();

    public string To => $@"{ _request.Action.Email }";
    
    public string Subject => $@"[{_request.Action.Name}][{_request.Amount},-] {_localize["NewActionRegistrationPayment.Emails.NewRegistrationPaymentReceived"]}";
    
    public string Body => $@"
        <div>
            <h1>{_localize["NewActionRegistrationPayment.Emails.InformNewRegistrationPaymentReceived"]}</h1>
            <h4>{_localize["NewActionRegistrationPayment.Emails.ReceivedInformations"]}:</h4>
            <table>
                <tr>
                    <td><b>{_localize["NewActionRegistrationPayment.Emails.Action"]}</b></td><td>{_request.Action.Name}</td>
                </tr>
                <tr>
                    <td><b>{_localize["NewActionRegistrationPayment.Emails.ReceivedAmount"]}</b></td><td>{_request.Amount}</td>
                </tr>
                {GenerateReceivedPaymentsHtml()}
            </table>
            <hr />
            <h5>{_localize["NewActionRegistration.Emails.InCaseOfUrgencyWriteUsAnEmailTo"]}: <i><a href='mailto:{_request.Action.Email}'>{_request.Action.Email}</a></i></h5>
        </div>
    ";
    
    public NewActionRegistrationPaymentReceivedEmailBuilder(ILocalizeService localizeService, NewActionRegistrationPaymentEmailRequest request)
    {
        _localize = localizeService.Get();
        _request = request;
    }

    private string GenerateReceivedPaymentsHtml()
    {
        string ret = string.Empty;
        
        foreach (var payment in _request.ReceivedPayments)
        {
            ret += $@"
                <tr>
                    <td>{payment.Received}</td>
                    <td>{payment.Amount}</td>
                </tr>
            ";
        }

        return ret;
    }
}