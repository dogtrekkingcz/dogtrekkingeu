namespace PetsOnTrail.Interfaces.Actions.Entities.UserProfile;

public sealed record GetSelectedSurnameNameResponse
{
    public List<SelectedSurnameNameDto> Items { get; set; } = new();

    public sealed record SelectedSurnameNameDto
    {
        public string Id { get; set; }
        
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        
        public string Nickname { get; set; }
    }
}