namespace DogtrekkingCzShared.Entities
{
    public record DogDto
    {
        public string? Id { get; set; }

        public string UserId { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public string Kennel { get; set; } = string.Empty;

        public string Pedigree { get; set; } = string.Empty;

        public string Chip { get; set; } = string.Empty;

        public DateTimeOffset Birthday { get; set; } = DateTimeOffset.Now;

        public DateTimeOffset Decease { get; set; } = DateTimeOffset.MaxValue;

        public string UriToPhoto { get; set; } = string.Empty;

        public string Contact { get; set; } = string.Empty;

        public List<VaccinationDto> Vaccinations { get; set; } = new List<VaccinationDto>();


        public sealed record VaccinationDto
        {
            public DateTimeOffset Date { get; set; } = DateTimeOffset.Now;

            public DateTimeOffset ValidUntil { get; set; } = DateTimeOffset.Now;

            public VaccinationType Type { get; set; } = VaccinationType.NotValid;

            public string UriToPhoto { get; set; } = string.Empty;

            public string Note { get; set; } = string.Empty;
        }

        public enum VaccinationType
        {
            NotValid = 0,
            Vzteklina = 1,
            Psinka = 2,
            Parvoviroza = 3,
            HepatitidaContagiosaCanis = 4,
            Leptospiroza = 5,
            Parainfluenza = 6,
            LymskaBorelioza = 7,
            Babesioza = 8,
            PlisnoveInfekce = 9,
            Leishmanioza = 10
        }
    }
}
