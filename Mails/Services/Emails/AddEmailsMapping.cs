using Microsoft.Extensions.DependencyInjection;

namespace Mails.Services.Emails;

public class AddEmailsMapping
{
    public AddEmailsMapping()
    {
        services.AddScoped<IMailSenderService, MailSenderService>();
    }
}