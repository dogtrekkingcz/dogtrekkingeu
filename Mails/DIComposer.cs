using Mails.Services;
using Mails.Services.Emails;
using Mapster;
using Microsoft.Extensions.DependencyInjection;
using SharedCode.Options;

namespace Mails;

public static class DIComposer
{
    public static IServiceCollection AddEmails(this IServiceCollection services, TypeAdapterConfig typeAdapterConfig, DogsOnTrailOptions options)
    {
        services.AddEmails(typeAdapterConfig, options);
        services.AddScoped<IMailSenderService, MailSenderService>();
        
        
        return services;
    }
}