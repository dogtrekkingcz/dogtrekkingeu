using SharedCode.Extensions;
using Mapster;

namespace DogsOnTrailApp.Models;

internal static class EntryModelMapping
{
    internal static TypeAdapterConfig AddEntryModelMapping(this TypeAdapterConfig typeAdapterConfig)
    {
        typeAdapterConfig.NewConfig<Protos.Shared.Entry, EntryModel>()
            .IgnoreNullValues(true)
            .Map(d => d.Created, s => s.Created.ToDateTimeOffset());
        typeAdapterConfig.NewConfig<Protos.Shared.EntryDog, EntryModel.DogDto>()
            .IgnoreNullValues(true)
            .Map(d => d.Birthday, s => s.Birthday.ToDateTimeOffset());

        typeAdapterConfig.NewConfig<EntryModel, Protos.Shared.Entry>()
            .IgnoreNullValues(true);
        typeAdapterConfig.NewConfig<EntryModel.DogDto, Protos.Shared.EntryDog>()
            .IgnoreNullValues(true)
            .Map(d => d.Birthday, s => s.Birthday != null ? s.Birthday.Value.ToGoogleDateTime() : null);

        typeAdapterConfig.NewConfig<EntryModel, Protos.Entries.CreateEntryRequest>()
            .Ignore(d => d.Entry.Id)
            .Ignore(d => d.Entry.Created);

        return typeAdapterConfig;
    }
}