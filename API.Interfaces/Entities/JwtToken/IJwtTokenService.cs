namespace PetsOnTrail.Interfaces.Actions.Entities.JwtToken;

public interface IJwtTokenService
{
    public void Parse(string token);

    public string GetUserId();
}

