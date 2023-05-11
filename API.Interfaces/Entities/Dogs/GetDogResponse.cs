using SharedCode.Entities;

namespace DogsOnTrail.Interfaces.Actions.Entities.Dogs;

public record GetDogResponse
{
    public IList<DogDto> Dogs { get; set; } = new List<DogDto>();
}