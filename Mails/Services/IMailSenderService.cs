using Mails.Builders.Emails;

namespace Mails.Services;

public interface IMailSenderService
{
    Task SendAsync(IEnumerable<IEmailBuilder> data, CancellationToken cancellationToken);
}