using FisSst.BlazorMaps;
using Microsoft.AspNetCore.Components;
using PetsOnTrailApp.Models;

namespace PetsOnTrailApp.Components.ActivityView;

public class UserActivitiesViewBase : ComponentBase
{
    [Parameter] public string UserId { get; set; }

    [Inject] private IUserProfileService _userProfileService { get; set; }
    [Inject] private NavigationManager Navigation { get; set; }

    public ActivityModel Model = null;

    protected async override void OnInitialized()
    {
        base.OnInitialized();

        var user = await _userProfileService.(UserId, CancellationToken.None);
        Model = await _activityRepository.GetActivityByUserIdAndActivityId(new Protos.Activities.UserIdAndActivityId { UserId = UserId, ActivityId = ActivityId }, CancellationToken.None);

        var left = Model.Positions.Min(p => p.Latitude);
        var right = Model.Positions.Max(p => p.Latitude);
        var top = Model.Positions.Max(p => p.Longitude);
        var bottom = Model.Positions.Min(p => p.Longitude);

        var center = new LatLng((left + right) / 2, (top + bottom) / 2);

        mapOptions = new MapOptions()
        {
            DivId = "mapId",
            Center = center,
            Zoom = 13,
            UrlTileLayer = "https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png",
            SubOptions = new MapSubOptions()
            {
                Attribution = "&copy; <a lhref='http://www.openstreetmap.org/copyright'>OpenStreetMap</a>",
                TileSize = 512,
                ZoomOffset = -1,
                MaxZoom = 19,
            }
        };

        StateHasChanged();
    }

    protected async Task LoadAsync()
    {
        //Model.Positions.Select(async p =>
        //    await MarkerFactory.CreateAndAddToMap(new LatLng(p.Latitude, p.Longitude), mapRef)
        //);

        await PolylineFactory.CreateAndAddToMap(Model.Positions.Select(p => new LatLng(p.Latitude, p.Longitude)).ToList(), mapRef);

        StateHasChanged();
    }
}
