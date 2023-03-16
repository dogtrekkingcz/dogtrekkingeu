using Mapster;
using Storage.Entities.Dogs;
using Storage.Models;

namespace Storage.Services.Repositories
{
    internal static class DogsRepositoryMapping
    {
        internal static TypeAdapterConfig AddDogsRepositoryMapping(this TypeAdapterConfig typeAdapterConfig)
        {
            typeAdapterConfig.NewConfig<AddDogRequest, DogRecord>()
                .Ignore(d => d.Id);

            return typeAdapterConfig;
        }
    }
}