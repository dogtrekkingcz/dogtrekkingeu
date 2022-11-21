using MongoDB.Driver.GeoJsonObjectModel;

namespace Storage.Interfaces.Entities;

public sealed record AddActionRequest
{
    public required string Name { get; set; }
    
    public DateTime From { get; set; }
    
    public DateTime To { get; set; }
    
    public DateTime PublishDate { get; set; }
    
    public string City { get; set; }
    
    public string Address { get; set; }
    
    public AddressRecord Gps { get; set; }
    
    public OwnerRecord Owner { get; set; }
    
    public IList<EventRecord> Events { get; set; }

    public IList<RaceRecord> Races { get; set; }


    public sealed record AddressRecord
    {
        public string City { get; set; }
        
        public string Street { get; set; }
        
        public string Longitude { get; set; }
        
        public string Latitude { get; set; }
    }
    public sealed record RaceRecord
    {
        public string Name { get; set; }
        
        public float Length { get; set; }
        
        public IList<CategoryRecord> Categories { get; set; }
    }

    public sealed record CategoryRecord
    {
        public string SeriesCategoryId { get; set; }
        
        public string Name { get; set; }
        
        public IList<CompetitorRecord> Competitors { get; set; }
    }

    public sealed record CompetitorRecord
    {
        public string SeriesCompetitorId { get; set; }
        
        public string Name { get; set; }
        
        public string Surname { get; set; }
        
        public string Email { get; set; }
        
        public string Phone { get; set; }
        
        public DateTime Start { get; set; }
        
        public DateTime Finish { get; set; }
        
        public FinishStateEnum FinishState { get; set; } 

        public bool IsStartingWithoutDog { get; set; }
        
        public IList<DogRecord> Dogs { get; set; }
    }


    public sealed record DogRecord
    {
        public string IdOwner { get; set; }
        
        public string Name { get; set; }
        
        public string Pedigree { get; set; }
        
        public string Chip { get; set; }
        
        public DateTime Birthday { get; set; }
    }
    
    public enum FinishStateEnum
    {
        NotStarted = 0,
        Started = 1,
        Finished = 2,
        DidNotFinished = 3,
        Disqualified = 4
    }
    
    public sealed record OwnerRecord
    {
        public string Email { get; set; }
        
        public string Phone { get; set; }
    }

    public enum EventType
    {
        Standard = 0,
        Cancelled = 1,
        
    } 
    public sealed record EventRecord
    {
        public DateTime When { get; set; }
        
        public EventType Type { get; set; }
        
        public DateTime ValidFrom { get; set; }
        
        public DateTime ValidTo { get; set; }
        
        public string Message { get; set; }
    }
}