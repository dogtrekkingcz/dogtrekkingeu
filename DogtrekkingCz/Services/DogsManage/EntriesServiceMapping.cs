using DogtrekkingCz.Interfaces.Actions.Entities.Dogs;
using DogtrekkingCz.Interfaces.Actions.Entities.Entries;
using Mapster;
using Storage.Entities.Dogs;
using Storage.Entities.Entries;
using GetAllDogsResponse = Storage.Entities.Dogs.GetAllDogsResponse;

namespace DogtrekkingCz.Actions.Services.DogsManage;

internal static class DogsServiceMapping
{
    public static TypeAdapterConfig AddDogsMapping(this TypeAdapterConfig typeAdapterConfig)
    {
        typeAdapterConfig.NewConfig<CreateDogRequest, AddDogRequest>();
        typeAdapterConfig.NewConfig<AddDogResponse, CreateEntryResponse>();

        typeAdapterConfig.NewConfig<GetAllDogsResponse, GetAllDogsResponse>();
        
        return typeAdapterConfig;
    }
}