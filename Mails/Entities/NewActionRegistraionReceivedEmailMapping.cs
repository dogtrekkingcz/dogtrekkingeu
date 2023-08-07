using Mapster;

namespace Mails.Entities;

public static class NewActionRegistrationReceivedEmailMapping
{
    private static Dictionary<NewActionRegistrationEmailRequest.TermDto, NewActionRegistrationEmailRequest.PaymentDto>
        CreateCopyOfPayments(
            Dictionary<NewActionRegistrationEmailRequest.TermDto, NewActionRegistrationEmailRequest.PaymentDto> src)
    {
        Dictionary<NewActionRegistrationEmailRequest.TermDto, NewActionRegistrationEmailRequest.PaymentDto> ret =
            new Dictionary<NewActionRegistrationEmailRequest.TermDto, NewActionRegistrationEmailRequest.PaymentDto>();

        foreach (var item in src)
        {
            ret.Add(item.Key, item.Value);
        }
        
        return ret;
    }
    public static TypeAdapterConfig AddNewActionRegistrationEmailMapping(this TypeAdapterConfig typeAdapterConfig)
    {
        typeAdapterConfig.NewConfig<NewActionRegistrationEmailRequest, NewActionRegistrationEmailRequest>()
            .Map(d => d.Payments, s => CreateCopyOfPayments(s.Payments))
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
            .NewConfig<NewActionRegistrationEmailRequest.PetDto, NewActionRegistrationEmailRequest.PetDto>()
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

        typeAdapterConfig
                .NewConfig<Dictionary<NewActionRegistrationEmailRequest.TermDto, NewActionRegistrationEmailRequest.PaymentDto>, Dictionary<NewActionRegistrationEmailRequest.TermDto, NewActionRegistrationEmailRequest.PaymentDto>>()
                .MapWith(s => CreateCopyOfPayments(s));

        typeAdapterConfig
            .NewConfig<
                KeyValuePair<NewActionRegistrationEmailRequest.TermDto, NewActionRegistrationEmailRequest.PaymentDto>,
                KeyValuePair<NewActionRegistrationEmailRequest.TermDto, NewActionRegistrationEmailRequest.PaymentDto>>()
            .IgnoreNullValues(true)
            .TwoWays();
        
        typeAdapterConfig.NewConfig<NewActionRegistrationEmailRequest.AddressDto, NewActionRegistrationEmailRequest.AddressDto>()
            .IgnoreNullValues(true)
            .TwoWays();
        
        typeAdapterConfig.NewConfig<NewActionRegistrationEmailRequest.LatLngDto, NewActionRegistrationEmailRequest.LatLngDto>()
            .IgnoreNullValues(true)
            .TwoWays();
        
        typeAdapterConfig.NewConfig<NewActionRegistrationEmailRequest.MerchandizeItemDto, NewActionRegistrationEmailRequest.MerchandizeItemDto>()
            .IgnoreNullValues(true)
            .TwoWays();
        
        return typeAdapterConfig;
    }
}