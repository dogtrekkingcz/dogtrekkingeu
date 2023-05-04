namespace DogtrekkingCzShared.Entities
{
    public enum RaceState
    {
        NotValid = 0,
        NotStarted,
        Started,
        Finished,
        DidNotFinished,
        Disqualified
    }

    public record RacerDto
    {
        public string Id { get; set; } = string.Empty;
        
        public string CompetitorId { get; set; } = string.Empty;

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public List<DogDto> Dogs { get; set; } = new List<DogDto>();

        public DateTimeOffset? Start { get; set; } = null;

        public DateTimeOffset? Finish { get; set; } = null;

        public RaceState State { get; set; } = RaceState.NotValid;

        public bool Accepted { get; set; } = false;

        public List<NoteDto> Notes { get; set; } = new List<NoteDto>();
    }
}
