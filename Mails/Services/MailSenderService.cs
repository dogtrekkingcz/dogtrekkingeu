using MimeKit;
using System.IO;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MailKit.Security;
using Mails.Services.Emails;

namespace Mails.Services;

public class MailSenderService : IMailSenderService
{
    public async Task SendAsync(IEmailBuilderService model, CancellationToken cancellationToken)
    {
        var email = new MimeMessage();
        email.Sender = MailboxAddress.Parse("no-reply@dogsontrail.eu");
        email.To.Add(MailboxAddress.Parse(model.To));
        email.Subject = model.Subject;
        var builder = new BodyBuilder();
        {
            byte[] fileBytes;
            
            foreach (var file in model.Attachments)
            {
                if (file.Length > 0)
                {
                    using (var ms = new MemoryStream())
                    {
                        file.CopyTo(ms);
                        fileBytes = ms.ToArray();
                    }
                    builder.Attachments.Add(file.FileName, fileBytes, ContentType.Parse(file.ContentType));
                }
            }
        }
        builder.HtmlBody = model.Body;
        email.Body = builder.ToMessageBody();
        
        using var smtp = new SmtpClient();
        await smtp.ConnectAsync("mail", 25, SecureSocketOptions.Auto, cancellationToken: cancellationToken);
        await smtp.SendAsync(email, cancellationToken: cancellationToken);
        await smtp.DisconnectAsync(true, cancellationToken: cancellationToken);
    }
}