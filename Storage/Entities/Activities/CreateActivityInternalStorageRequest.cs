﻿namespace Storage.Entities.Activities;

public sealed record CreateActivityInternalStorageRequest
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public string UserId { get; set; } = string.Empty;

    public Guid ActionId { get; set; } = Guid.Empty;

    public Guid RaceId { get; set; } = Guid.Empty;

    public Guid CategoryId { get; set; } = Guid.Empty;
        
    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;
        
    public DateTimeOffset Start { get; set; } = DateTimeOffset.Now;

    public DateTimeOffset? End { get; set; } = null;

    public bool IsPublic { get; set; } = true;
    
    public List<Guid> PetIds { get; set; } = new();

    public IEnumerable<PositionDto> Positions { get; set; } = new List<PositionDto>(0);

    public sealed record PositionDto
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        
        public DateTimeOffset Time { get; set; } = DateTimeOffset.Now;
            
        public double Latitude { get; set; } = double.NaN;

        public double Longitude { get; set; } = double.NaN;

        public double Altitude { get; set; } = double.NaN;

        public double Accuracy { get; set; } = double.NaN;

        public double Course { get; set; } = double.NaN;

        public string Note { get; set; } = string.Empty;
        
        public List<string> PhotoUris { get; set; } = new();
    }
}