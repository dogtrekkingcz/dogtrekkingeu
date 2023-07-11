using MimeKit;
using System.IO;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MailKit.Security;
using Mails.Services.Emails;
using Mapster.Models;
using Microsoft.AspNetCore.Http;

namespace Mails.Services;

public class MailSenderService : IMailSenderService
{
    public async Task SendAsync(IEmailBuilderService model, CancellationToken cancellationToken)
    {
        using var smtp = new SmtpClient();
        
        await smtp.ConnectAsync("mail", 25, SecureSocketOptions.Auto, cancellationToken: cancellationToken);
        
        await Task.WhenAll(
            SendMailAsync(smtp, model.ToAdmin, model.SubjectAdmin, model.BodyAdmin, model.Attachments, cancellationToken),
            SendMailAsync(smtp, model.ToRacer, model.SubjectRacer, model.BodyRacer, model.Attachments, cancellationToken));
        
        await smtp.DisconnectAsync(true, cancellationToken: cancellationToken);
    }

    private async Task SendMailAsync(SmtpClient smtp, string to, string subject, string body, IList<IFormFile> attachments, CancellationToken cancellationToken)
    {
        var email = new MimeMessage();
        email.Sender = MailboxAddress.Parse("no-reply@dogsontrail.eu");
        email.To.Add(MailboxAddress.Parse(to));
        email.Subject = subject;
        
        var builder = new BodyBuilder();
        {
            byte[] fileBytes;
            
            foreach (var file in attachments)
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
        
        builder.HtmlBody = body;
        email.Body = builder.ToMessageBody();
        
        await smtp.SendAsync(email, cancellationToken: cancellationToken);
    }
}