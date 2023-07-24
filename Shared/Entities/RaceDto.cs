namespace SharedCode.Entities
{
    public sealed record Race___Dto
    {
        public Guid Id { get; set; } = default(Guid);
        public string Name { get; set; } = string.Empty;
        
        public double? Distance { get; set; } = 0.0;
        
        public double? Incline { get; set; } = 0.0;

        public DateTimeOffset EnteringFrom = DateTimeOffset.Now;
        
        public DateTimeOffset EnteringTo = DateTimeOffset.Now.AddYears(1);
        
        public int MaxNumberOfCompetitors = Int32.MaxValue;
        
        public DateTimeOffset Begin = DateTimeOffset.Now;
        
        public IList<Category___Dto> Categories { get; set; } = new List<Category___Dto>();

        public IList<PaymentDefinitionDto> Payments { get; set; } = new List<PaymentDefinitionDto>();

        public LimitsDto Limits { get; set; } = new();

        public sealed record PaymentDefinitionDto
        {
            public Guid Id { get; set; } = default(Guid);
            
            public string BankAccount { get; set; }
            
            public DateTimeOffset From { get; set; }
            
            public DateTimeOffset To { get; set; }
            
            public double Price { get; set; }

            public string Currency { get; set; } = "Kc";
        }

        public sealed record LimitsDto
        {
            public int MinimalAgeOfRacerInDayes { get; set; } = 0;
            
            public int MinimalAgeOfTheDogInDayes { get; set; } = 0;

            public bool WithDogs { get; set; } = true;
        }
    }
}
