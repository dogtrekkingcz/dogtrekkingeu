using SharedCode.Extensions;
using Mapster;
using SharedCode.Entities;

namespace SharedCode.Mapping
{
    public static class SharedMappingNote
    {
        public static TypeAdapterConfig AddSharedMappingNote(this TypeAdapterConfig typeAdapterConfig)
        {
            typeAdapterConfig.NewConfig<NoteDto, Protos.Shared.Note>()
                .Map(d => d.Time, s => s.Time.ToGoogleDateTime());

            // typeAdapterConfig.NewConfig<Protos.Shared.Note, NoteDto>()
            //     .Map(d => d.Time, s => s.Time.ToDateTimeOffset());

            typeAdapterConfig.NewConfig<NoteDto, NoteDto>();

            return typeAdapterConfig;
        }
    }
}
