namespace DogtrekkingCz.Shared.Entities
{
    public record DogDto
    {
        public string? Id { get; set; }

        public string Name { get; set; }

        public string Pedigree { get; set; }

        public string Chip { get; set; }

        public DateTimeOffset Birthday { get; set; }

        public DateTimeOffset? Decease { get; set; } = null;

        public string UserProfileUri { get; set; }


        public List<VaccinationDto> Vaccinations { get; set; }


        public sealed record VaccinationDto
        {
            public DateTimeOffset Date { get; set; }

            public DateTimeOffset ValidUntil { get; set; }

            public VaccinationType Type { get; set; }

            public string UriToPhoto { get; set; }

            public string Note { get; set; }
        }

        public enum VaccinationType
        {
            Vzteklina = 0,
            Psinka = 1,
            Parvoviroza = 2,
            HepatitidaContagiosaCanis = 3,
            Leptospiroza = 4,
            Parainfluenza = 5,
            LymskaBorelioza = 6,
            Babesioza = 7,
            PlisnoveInfekce = 8,
            Leishmanioza = 9
        }
    }
}
