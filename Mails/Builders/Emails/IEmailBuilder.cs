using Microsoft.AspNetCore.Http;

namespace Mails.Builders.Emails;


public interface IEmailBuilder
{
    public string To { get; }
    
    public string Subject { get; }
    
    public string Body { get; }

    public List<IFormFile> Attachments { get; set; }
}