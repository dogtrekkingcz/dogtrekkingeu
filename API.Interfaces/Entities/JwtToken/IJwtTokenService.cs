namespace PetsOnTrail.Interfaces.Actions.Entities.JwtToken;

public interface IJwtTokenService
{
    public Task<string> Parse(string token, CancellationToken cancellationToken);

    public Guid GetUserId();
}

