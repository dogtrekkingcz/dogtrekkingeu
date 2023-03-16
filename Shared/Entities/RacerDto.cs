namespace DogtrekkingCz.Shared.Entities
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

    public sealed record RacerDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public List<string> Dogs { get; set; }

        public DateTimeOffset? Start { get; set; }

        public DateTimeOffset? Finish { get; set; }

        public RaceState State { get; set; }

        public List<NoteDto> Notes { get; set; }
    }
}
