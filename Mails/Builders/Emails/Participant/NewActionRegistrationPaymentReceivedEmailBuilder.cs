using Mails.Entities.PaymentOfRegistrationReceived;
using Mails.Services;
using Microsoft.AspNetCore.Http;

namespace Mails.Builders.Emails.Participant;

public sealed class NewActionRegistrationPaymentReceivedEmailBuilder : IEmailBuilder
{
    private readonly ILocalizeService _localizeService;
    private NewActionRegistrationPaymentEmailRequest _request { get; }

    public List<IFormFile> Attachments { get; set; } = new();

    public string To => $@"{ _request.Action.Email }";
    
    public string Subject => $@"[{_request.Action.Name}][{_request.Amount},-] {_localizeService.Get("NewActionRegistrationPayment.Emails.NewRegistrationPaymentReceived")}";
    
    public string Body => $@"
        <div>
            <h1>{_localizeService.Get("NewActionRegistrationPayment.Emails.InformNewRegistrationPaymentReceived")}</h1>
            <h4>{_localizeService.Get("NewActionRegistrationPayment.Emails.ReceivedInformations")}:</h4>
            <table>
                <tr>
                    <td><b>{_localizeService.Get("NewActionRegistrationPayment.Emails.Action")}</b></td><td>{_request.Action.Name}</td>
                </tr>
                <tr>
                    <td><b>{_localizeService.Get("NewActionRegistrationPayment.Emails.ReceivedAmount")}</b></td><td>{_request.Amount}</td>
                </tr>
                {GenerateReceivedPaymentsHtml()}
            </table>
            <hr />
            <h5>{_localizeService.Get("NewActionRegistration.Emails.InCaseOfUrgencyWriteUsAnEmailTo")}: <i><a href='mailto:{_request.Action.Email}'>{_request.Action.Email}</a></i></h5>
        </div>
    ";
    
    public NewActionRegistrationPaymentReceivedEmailBuilder(ILocalizeService localizeService, NewActionRegistrationPaymentEmailRequest request)
    {
        _localizeService = localizeService;
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