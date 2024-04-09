namespace PetsOnTrail.Interfaces.Actions.Services;

public interface ICurrentUserIdService
{
    void SetUserId(string userId);
    
    string GetUserId();
}