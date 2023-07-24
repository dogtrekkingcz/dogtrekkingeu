using SharedCode.Extensions;
using Mapster;
using SharedCode.Entities;

namespace DogsOnTrailApp.Models;

internal static class EntryModelMapping
{
    internal static TypeAdapterConfig AddEntryModelMapping(this TypeAdapterConfig typeAdapterConfig)
    {
        typeAdapterConfig.NewConfig<Protos.Shared.Entry, EntryModel>()
            .IgnoreNullValues(true)
            .Map(d => d.Created, s => s.Created.ToDateTimeOffset())
            .Map(d => d.Birthday, s => s.Birthday.ToDateTimeOffset());
        
        typeAdapterConfig.NewConfig<Protos.Shared.EntryDog, EntryModel.DogDto>()
            .IgnoreNullValues(true)
            .Map(d => d.Birthday, s => s.Birthday.ToDateTimeOffset());

        typeAdapterConfig.NewConfig<EntryModel, Protos.Shared.Entry>()
            .IgnoreNullValues(true)
            .Map(d => d.AcceptedDate, s => (Google.Type.DateTime) null)
            .Map(d => d.Accepted, s => false);
            
        typeAdapterConfig.NewConfig<EntryModel.DogDto, Protos.Shared.EntryDog>()
            .IgnoreNullValues(true)
            .Map(d => d.Birthday, s => s.Birthday != null ? s.Birthday.ToGoogleDateTime() : null);
        typeAdapterConfig.NewConfig<EntryModel.VaccinationDto, Protos.Shared.Vaccination>()
            .IgnoreNullValues(true)
            .Map(d => d.Date, s => s.Date != null ? s.Date.ToGoogleDateTime() : null)
            .Map(d => d.ValidUntil, s => s.ValidUntil != null ? s.ValidUntil.ToGoogleDateTime() : null);

        typeAdapterConfig.NewConfig<Protos.Shared.Vaccination, EntryModel.VaccinationDto>()
            .IgnoreNullValues(true)
            .Map(d => d.Date, s => s.Date.ToDateTimeOffset())
            .Map(d => d.ValidUntil, s => s.ValidUntil.ToDateTimeOffset());

        typeAdapterConfig.NewConfig<EntryModel, Protos.Entries.CreateEntryRequest>();
        typeAdapterConfig.NewConfig<EntryModel.VaccinationDto, Protos.Entries.CreateEntryRequest_Vaccination>();
        typeAdapterConfig.NewConfig<EntryModel.DogDto, Protos.Entries.CreateEntryRequest_Dog>();
        typeAdapterConfig.NewConfig<EntryModel.VaccinationType, Protos.Entries.CreateEntryRequest_VaccinationType>();

        return typeAdapterConfig;
    }
}