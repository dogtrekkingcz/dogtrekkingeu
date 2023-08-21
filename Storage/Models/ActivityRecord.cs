namespace Storage.Models
{
    internal sealed record ActivityRecord : IRecord
    {
        public string? Id { get; set; }

        public string UserId { get; set; } = string.Empty;

        public string ActionId { get; set; } = Guid.Empty.ToString();

        public string RaceId { get; set; } = Guid.Empty.ToString();

        public string CategoryId { get; set; } = Guid.Empty.ToString();
        
        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;
        
        public DateTimeOffset Start { get; set; } = DateTimeOffset.Now;

        public DateTimeOffset? End { get; set; } = null;

        public bool IsPublic { get; set; } = true;

        public List<PositionDto> Positions { get; set; } = new();

        public sealed record PositionDto
        {
            public string Id { get; set; } = Guid.NewGuid().ToString();
            
            public DateTimeOffset Time { get; set; } = DateTimeOffset.Now;
            
            public double Latitude { get; set; } = double.NaN;

            public double Longitude { get; set; } = double.NaN;

            public double Altitude { get; set; } = double.NaN;

            public double Accuracy { get; set; } = double.NaN;

            public double Course { get; set; } = double.NaN;

            public string Note { get; set; } = string.Empty;
        }
    }
}
