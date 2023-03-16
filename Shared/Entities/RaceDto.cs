namespace DogtrekkingCz.Shared.Entities
{
    public sealed record RaceDto
    {
        public Guid Id { get; set; } = default(Guid);
        public string Name { get; set; } = string.Empty;
        public double? Distance { get; set; } = 0.0;
        public double? Incline { get; set; } = 0.0;

        public IList<CategoryDto> Categories { get; set; } = new List<CategoryDto>();
    }
}
