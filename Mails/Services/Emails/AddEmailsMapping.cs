using System.Runtime.CompilerServices;
using Mails.Entities;
using Mapster;
using Microsoft.Extensions.DependencyInjection;

namespace Mails.Services.Emails;

internal static class EmailsServiceMapping
{
    internal static TypeAdapterConfig AddEmailsMapping(this TypeAdapterConfig typeAdapterConfig)
    {
        typeAdapterConfig
            .NewConfig<NewActionRegistrationEmailRequest.ActionDto, NewActionRegistrationEmailRequest.ActionDto>()
            .IgnoreNullValues(true)
            .TwoWays();
        
        return typeAdapterConfig;
    }
}