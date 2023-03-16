using Mapster;
using DogtrekkingCz.Shared.Entities;
using DogtrekkingCz.Shared.Extensions;

namespace DogtrekkingCz.Shared.Mapping
{
    public static class SharedMappingContact
    {
        public static TypeAdapterConfig AddSharedMappingContact(this TypeAdapterConfig typeAdapterConfig)
        {
            typeAdapterConfig.NewConfig<ContactDto, Protos.Shared.Contact>()
                .TwoWays();

            typeAdapterConfig.NewConfig<ContactDto, ContactDto>();

            return typeAdapterConfig;
        }
    }
}
