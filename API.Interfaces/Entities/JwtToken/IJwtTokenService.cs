namespace PetsOnTrail.Interfaces.Actions.Entities.JwtToken;

public interface IJwtTokenService
{
    public string Parse(string token);

    public Guid GetUserId();
}

