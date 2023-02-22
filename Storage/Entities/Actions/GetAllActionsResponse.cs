using DogtrekkingCz.Storage.Models;

namespace Storage.Entities.Actions;

public sealed record GetAllActionsResponse
{
    public IReadOnlyList<ActionDto> Actions { get; init; }

    public sealed record ActionDto
    {
        public string Id { get; set; }
        
        public string Name { get; set; }

        public OwnerDto Owner { get; set; }

        public string Description { get; set; }
        
        public TermDto Term { get; set; }
        
        public AddressDto Address { get; set; }

        public IReadOnlyList<RaceDto> Races { get; set; }
        
        public FlagsDto Flags { get; set; }
    }

    public sealed record OwnerDto
    {
        public string Id { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string FamilyName { get; set; }
    }

    public sealed record TermDto
    {
        public DateTimeOffset From { get; set; }
        public DateTimeOffset To { get; set; }
    }
    
    public sealed record AddressDto
    {
        public string Country { get; set; }
        public string Region { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public double GpsLatitude { get; set; }
        public double GpsLongitude { get; set; }
    }

    public class RaceDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double? Distance { get; set; }
        public double? Incline { get; set; }

        public IList<CategoryDto> Categories { get; set; }
    }

    public class CategoryDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public IList<RacerDto> Racers { get; set; }
    }

    public class RacerDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Phone { get; set; }
        public string Email { get; set; }

        public string City { get; set; }
        public string Address { get; set; }

        public DateTimeOffset Birthday { get; set; }


        public List<DogDto> Dogs { get; set; }

        public DateTimeOffset Start { get; set; }
        public DateTimeOffset Finish { get; set; }

        public IList<CheckpointDto> Checkpoints { get; set; }

        public RaceState State { get; set; }

        public DateTimeOffset Received { get; set; }
        public DateTimeOffset Payed { get; set; }

        public List<NoteDto> Notes { get; set; }
    }

    public class NoteDto
    {
        public DateTimeOffset Date { get; set; }
        public string Note { get; set; }
    }

    public class DogDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Pedigree { get; set; }
        public string Chip { get; set; }
    }

    public class CheckpointDto
    {
        public Guid Id { get; set; }
        public DateTimeOffset Passed { get; set; }
    }
    
    public class FlagsDto
    {
        public bool IsHidden { get; set; }
        
        public bool IsCanceled { get; set; }
        public string CancelledReason { get; set; }
        
        public bool TermLocked { get; set; }
        
        public bool Approved { get; set; }
    }

    public enum RaceState
    {
        NotStarted = 0,
        Started,
        Finished,
        DidNotFinished,
        Disqualified
    }
}