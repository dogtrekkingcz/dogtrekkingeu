using PetsOnTrail.Interfaces.Actions.Services;

namespace PetsOnTrail.Actions.Services.CurrentUserId;

public class CurrentUserIdService : ICurrentUserIdService
{
    private Guid _currentUserId = Guid.Empty;
    
    public void SetUserId(Guid userId)
    {
        _currentUserId = userId;
    }
    
    public Guid GetUserId()
    {
        return _currentUserId;
    }
}