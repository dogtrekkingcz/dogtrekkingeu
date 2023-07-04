using Mails.Services.Emails;

namespace Mails.Services;

public interface IMailSenderService
{
    Task SendAsync(IEmailBuilderService data, CancellationToken cancellationToken);
}