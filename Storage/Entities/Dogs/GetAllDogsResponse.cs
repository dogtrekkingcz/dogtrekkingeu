using DogtrekkingCzShared.Entities;

namespace Storage.Entities.Dogs;

public record GetAllDogsResponse
{
    public IList<DogDto> Dogs { get; set;  }
}