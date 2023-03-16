namespace DogtrekkingCz.Shared.Entities
{
    public sealed record RaceDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double? Distance { get; set; }
        public double? Incline { get; set; }

        public IList<CategoryDto> Categories { get; set; }
    }
}
