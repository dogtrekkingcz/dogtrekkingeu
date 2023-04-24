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
                .Map(d => d.Birthday, s => (Google.Type.DateTime) s.Birthday.ToGoogleDateTime())
                .Map(d => d.Decease, s => (Google.Type.DateTime) (s.Decease.ToGoogleDateTime()));

            typeAdapterConfig.NewConfig<Protos.Shared.Dog, DogDto>()
                .IgnoreNullValues(true)
                .Map(d => d.Birthday, s => s.Birthday.ToDateTimeOffset())
                .Map(d => d.Decease, s => s.Decease.ToDateTimeOffset());

            // -----------

            typeAdapterConfig.NewConfig<DogDto.VaccinationDto, Protos.Shared.Vaccination>()
                .Map(d => d.Date, s => (Google.Type.DateTime) s.Date.ToGoogleDateTime())
                .Map(d => d.ValidUntil, s => (Google.Type.DateTime) s.ValidUntil.ToGoogleDateTime());

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
