using System.Collections.ObjectModel;
using DogsOnTrail.Interfaces.Actions.Entities.LiveUpdateSubscription;

namespace DogsOnTrail.Interfaces.Actions.Services;

public interface ILiveUpdateRepositoryService
{
    IDictionary<string, ObservableCollection<LiveUpdateSubscriptionItem>> Repository { get; set; }
}