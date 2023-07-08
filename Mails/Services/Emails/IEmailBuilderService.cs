using Microsoft.AspNetCore.Http;

namespace Mails.Services.Emails;


public interface IEmailBuilderService
{
    public string To { get; }
    
    public string Subject { get; }
    
    public string Body { get; }

    public List<IFormFile> Attachments { get; set; }
}