using Mails.Builders.Emails;
using Mails.Options;
using Mails.Services;
using Mapster;
using Microsoft.Extensions.DependencyInjection;

namespace Mails;

public static class DiComposer
{
    public static IServiceCollection AddEmails(this IServiceCollection services, TypeAdapterConfig typeAdapterConfig, DogsOnTrailOptions options)
    {
        typeAdapterConfig.AddEmailsMapping();
        
        services.AddScoped<IMailSenderService, MailSenderService>();
        
        return services;
    }
}