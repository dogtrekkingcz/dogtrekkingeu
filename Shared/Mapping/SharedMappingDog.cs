using DogtrekkingCzShared.Entities;
using DogtrekkingCzShared.Extensions;
using Mapster;

namespace DogtrekkingCzShared.Mapping
{
    public static class SharedMappingDog
    {
        public static TypeAdapterConfig AddSharedMappingDog(this TypeAdapterConfig typeAdapterConfig)
        {
            typeAdapterConfig.NewConfig<DogDto, Protos.Shared.Dog>()
                .IgnoreNullValues(true)
                .Map(d => d.Birthday, s => s.Birthday != null ? (Google.Type.DateTime) s.Birthday.Value.ToGoogleDateTime() : null)
                .Map(d => d.Decease, s => s.Decease != null ? (Google.Type.DateTime) s.Decease.Value.ToGoogleDateTime() : null);

            typeAdapterConfig.NewConfig<Protos.Shared.Dog, DogDto>()
                .IgnoreNullValues(true)
                .Map(d => d.Birthday, s => s.Birthday.ToDateTimeOffset())
                .Map(d => d.Decease, s => s.Decease.ToDateTimeOffset());

            // -----------

            typeAdapterConfig.NewConfig<DogDto.VaccinationDto, Protos.Shared.Vaccination>()
                .Map(d => d.Date, s => s.Date != null ? (Google.Type.DateTime) s.Date.Value.ToGoogleDateTime() : null)
                .Map(d => d.ValidUntil, s => s.ValidUntil != null ? (Google.Type.DateTime) s.ValidUntil.Value.ToGoogleDateTime() : null);

            typeAdapterConfig.NewConfig<Protos.Shared.Vaccination, DogDto.VaccinationDto>()
                .Map(d => d.Date, s => s.Date.ToDateTimeOffset())
                .Map(d => d.ValidUntil, s => s.ValidUntil.ToDateTimeOffset());

            // ----------

            typeAdapterConfig.NewConfig<DogDto, DogDto>();
            typeAdapterConfig.NewConfig<DogDto.VaccinationDto, DogDto.VaccinationDto>();

            return typeAdapterConfig;
        }
    }
}
