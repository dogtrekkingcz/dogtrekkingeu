using Mapster;
using SharedCode.Entities;

namespace SharedCode.Mapping
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
