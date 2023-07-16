using Mails.Entities;
using Mapster;
using Microsoft.Extensions.DependencyInjection;

namespace Mails.Builders.Emails.Participant;

public static class NewActionRegistraionReceivedEmailMapping
{
    public static TypeAdapterConfig AddNewAtionRegistrationEmailMapping(this TypeAdapterConfig typeAdapterConfig)
    {
        typeAdapterConfig.NewConfig<NewActionRegistrationEmailRequest, NewActionRegistrationEmailRequest>()
            .IgnoreNullValues(true)
            .TwoWays();

        typeAdapterConfig
            .NewConfig<NewActionRegistrationEmailRequest.ActionDto, NewActionRegistrationEmailRequest.ActionDto>()
            .IgnoreNullValues(true)
            .TwoWays();

        typeAdapterConfig
            .NewConfig<NewActionRegistrationEmailRequest.CategoryDto, NewActionRegistrationEmailRequest.CategoryDto>()
            .IgnoreNullValues(true)
            .TwoWays();

        typeAdapterConfig
            .NewConfig<NewActionRegistrationEmailRequest.DogDto, NewActionRegistrationEmailRequest.DogDto>()
            .IgnoreNullValues(true)
            .TwoWays();

        typeAdapterConfig
            .NewConfig<NewActionRegistrationEmailRequest.RacerDto, NewActionRegistrationEmailRequest.RacerDto>()
            .IgnoreNullValues(true)
            .TwoWays();

        typeAdapterConfig
            .NewConfig<NewActionRegistrationEmailRequest.RaceDto, NewActionRegistrationEmailRequest.RaceDto>()
            .IgnoreNullValues(true)
            .TwoWays();

        typeAdapterConfig
            .NewConfig<NewActionRegistrationEmailRequest.PaymentDto, NewActionRegistrationEmailRequest.PaymentDto>()
            .IgnoreNullValues(true)
            .TwoWays();

        typeAdapterConfig
            .NewConfig<NewActionRegistrationEmailRequest.TermDto, NewActionRegistrationEmailRequest.TermDto>()
            .IgnoreNullValues(true)
            .TwoWays();

        typeAdapterConfig
            .NewConfig<NewActionRegistrationEmailRequest.VaccinationDto, NewActionRegistrationEmailRequest.VaccinationDto>()
            .IgnoreNullValues(true)
            .TwoWays();
        
        return typeAdapterConfig;
    }
}