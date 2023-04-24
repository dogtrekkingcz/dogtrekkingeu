using DogtrekkingCzShared.Entities;

namespace DogtrekkingCz.Interfaces.Actions.Entities.Dogs;

public record GetDogResponse
{
    public IList<DogDto> Dogs { get; set; } = new List<DogDto>();
}