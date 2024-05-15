namespace PetsOnTrail.Interfaces.Actions.Services;

public interface ICurrentUserIdService
{
    void SetUserId(Guid userId);
    
    Guid GetUserId();
}