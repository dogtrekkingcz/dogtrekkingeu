using DogtrekkingCzShared.Entities;

namespace Storage.Entities.Dogs;

public record GetAllDogsInternalStorageResponse
{
    public IList<DogDto> Dogs { get; set; } = new List<DogDto>();
}