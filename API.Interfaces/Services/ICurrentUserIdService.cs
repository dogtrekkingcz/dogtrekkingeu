namespace DogsOnTrail.Interfaces.Actions.Services;

public interface ICurrentUserIdService
{
    void SetUserId(string userId);
    
    string GetUserId();
}