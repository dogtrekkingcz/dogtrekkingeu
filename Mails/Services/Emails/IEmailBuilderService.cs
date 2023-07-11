using Microsoft.AspNetCore.Http;

namespace Mails.Services.Emails;


public interface IEmailBuilderService
{
    public string ToRacer { get; }
    
    public string ToAdmin { get; }
    
    public string SubjectAdmin { get; }
    
    public string BodyAdmin { get; }
    
    public string SubjectRacer { get; }
    
    public string BodyRacer { get; }

    public List<IFormFile> Attachments { get; set; }
}