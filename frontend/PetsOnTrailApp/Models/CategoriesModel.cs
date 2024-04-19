namespace PetsOnTrailApp.Models;

public sealed record CategoriesModel : BaseSynchronizedModel
{
    public Guid ActionId { get; set; }
    
    public Guid RaceId { get; set; }

    public List<CategoryDto> Categories { get; set; } = new();

    public sealed record CategoryDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}
