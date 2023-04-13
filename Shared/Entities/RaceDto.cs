namespace DogtrekkingCzShared.Entities
{
    public sealed record RaceDto
    {
        public Guid Id { get; set; } = default(Guid);
        public string Name { get; set; } = string.Empty;
        
        public double? Distance { get; set; } = 0.0;
        
        public double? Incline { get; set; } = 0.0;

        public DateTimeOffset EnteringFrom = DateTimeOffset.Now;
        
        public DateTimeOffset EnteringTo = DateTimeOffset.Now.AddYears(1);
        
        public int MaxNumberOfCompetitors = Int32.MaxValue;
        
        public IList<CategoryDto> Categories { get; set; } = new List<CategoryDto>();

        public IList<PaymentDefinitionDto> Payments { get; set; } = new List<PaymentDefinitionDto>();

        public sealed record PaymentDefinitionDto
        {
            public Guid Id { get; set; } = default(Guid);
            
            public DateTimeOffset From { get; set; }
            
            public DateTimeOffset To { get; set; }
            
            public double Price { get; set; }

            public string Currency { get; set; } = "Kc";
        }
    }
}
