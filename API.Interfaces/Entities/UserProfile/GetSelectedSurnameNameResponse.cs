namespace DogsOnTrail.Interfaces.Actions.Entities.UserProfile;

public sealed record GetSelectedSurnameNameResponse
{
    public List<SelectedSurnameNameDto> Items { get; set; } = new();

    public sealed record SelectedSurnameNameDto
    {
        public string Id { get; set; }
        
        public string Name { get; set; }
        
        public string Surname { get; set; }
        
        public string Nickname { get; set; }
    }
}