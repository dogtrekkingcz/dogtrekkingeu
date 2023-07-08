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

        typeAdapterConfig
            .NewConfig<NewActionRegistrationEmailRequest.RaceDto, NewActionRegistrationEmailRequest.RaceDto>()
            .IgnoreNullValues(true)
            .TwoWays();

        typeAdapterConfig
            .NewConfig<NewActionRegistrationEmailRequest.VaccinationDto, NewActionRegistrationEmailRequest.VaccinationDto>()
            .IgnoreNullValues(true)
            .TwoWays();

        typeAdapterConfig
            .NewConfig<NewActionRegistrationEmailRequest.DogDto, NewActionRegistrationEmailRequest.DogDto>()
            .IgnoreNullValues(true)
            .TwoWays();

        typeAdapterConfig
            .NewConfig<NewActionRegistrationEmailRequest.CategoryDto, NewActionRegistrationEmailRequest.CategoryDto>()
            .IgnoreNullValues(true)
            .TwoWays();

        typeAdapterConfig
            .NewConfig<NewActionRegistrationEmailRequest.RacerDto, NewActionRegistrationEmailRequest.RacerDto>()
            .IgnoreNullValues(true)
            .TwoWays();
        
        return typeAdapterConfig;
    }
}