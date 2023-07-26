using DogsOnTrail.Interfaces.Actions.Services;

namespace DogsOnTrail.Actions.Services.CurrentUserId;

public class CurrentUserIdService : ICurrentUserIdService
{
    private string _currentUserId = String.Empty;
    
    public void SetUserId(string userId)
    {
        _currentUserId = userId;
    }
    
    public string GetUserId()
    {
        return _currentUserId;
    }
}