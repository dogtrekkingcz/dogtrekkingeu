using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using SharedCode.Entities;

namespace DogsOnTrailApp.Models;

public sealed record EntryModel
{
    public string? Id { get; set; } = "";

    public string UserProfileId { get; set; } = "";
    
    public string CompetitorId { get; set; } = "";

    [Required]
    public string Name { get; set; } = "";

    [Required]
    public string Surname { get; set; } = "";

    [Required]
    public string Phone { get; set; } = "";

    [Required]
    [EmailAddress]
    public string Email { get; set; } = "";

    public List<DogDto> Dogs { get; set; } = new List<DogDto>();

    public List<string> Notes { get; set; } = new List<string>();

    public Guid ActionId { get; set; } = Guid.Empty;

    public Guid RaceId { get; set; } = Guid.Empty;

    public Guid CategoryId { get; set; } = Guid.Empty;

    public AddressDto Address { get; set; } = new();

    public DateTimeOffset? Birthday { get; set; } = null;
    
    public DateTimeOffset Created { get; set; } = DateTimeOffset.Now;

    public string LanguageCode { get; set; } = "en-US";
    
    public record DogDto
    {
        public string? Id { get; set; }
        
        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Pedigree { get; set; } = string.Empty;

        [Required]
        public string Chip { get; set; } = string.Empty;

        public DateTimeOffset? Birthday { get; set; } = null;

        public List<VaccinationDto> Vaccinations { get; set; } =
            new List<VaccinationDto>
            {
                new VaccinationDto
                {
                    Type = VaccinationType.Rabies
                }
            };
    }

    public sealed record VaccinationDto
    {
        public DateTimeOffset? Date { get; set; } = DateTimeOffset.Now;

        public DateTimeOffset? ValidUntil { get; set; } = DateTimeOffset.Now;

        public VaccinationType Type { get; set; } = VaccinationType.NotValid;

        public string UriToPhoto { get; set; } = string.Empty;

        public string Note { get; set; } = string.Empty;
    }

    public enum VaccinationType
    {
        NotValid = 0,
        Rabies = 1, // Vzteklina
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