using Mapster;
using DogtrekkingCz.Shared.Entities;
using DogtrekkingCz.Shared.Extensions;

namespace DogtrekkingCz.Shared.Mapping
{
    public static class SharedMappingNote
    {
        public static TypeAdapterConfig AddSharedMappingNote(this TypeAdapterConfig typeAdapterConfig)
        {
            typeAdapterConfig.NewConfig<NoteDto, Protos.Shared.Note>()
                .Map(d => d.Time, s => s.Date.ToGoogleDateTime());

            typeAdapterConfig.NewConfig<Protos.Shared.Note, NoteDto>()
                .Map(d => d.Date, s => s.Time.ToDateTimeOffset());

            return typeAdapterConfig;
        }
    }
}
