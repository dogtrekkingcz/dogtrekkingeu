using FisSst.BlazorMaps;
using Microsoft.AspNetCore.Components;
using Microsoft.Maui.ApplicationModel;
using PetsOnTrailApp.DataStorage.Repositories.ActivityRepository;
using PetsOnTrailApp.Extensions;
using PetsOnTrailApp.Models;

namespace PetsOnTrailApp.Components.ActivityView;

public class ActivityViewBase : ComponentBase
{
    [Parameter] public string UserId { get; set; }
    [Parameter] public string ActivityId { get; set; }

    [Inject] private IActivityRepository _activityRepository { get; set; }
    [Inject] private NavigationManager Navigation { get; set; }

    //[Inject] private IMarkerFactory MarkerFactory { get; init; }
    [Inject] private IPolylineFactory PolylineFactory { get; init; }


    protected FisSst.BlazorMaps.Map mapRef;
    protected MapOptions mapOptions;

    public ActivityModel Model = null;

    protected async override void OnInitialized()
    {
        base.OnInitialized();

        Model = await _activityRepository.GetActivityByUserIdAndActivityId(new Protos.Activities.UserIdAndActivityId { UserId = UserId, ActivityId = ActivityId }, CancellationToken.None);

        if (Model != null && Model.Positions.Count > 0)
        {
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
        }

        StateHasChanged();
    }

    protected async override Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender && Model != null && Model.Positions.Count > 0)
        {
            await PolylineFactory.CreateAndAddToMap(Model.Positions.Select(p => new LatLng(p.Latitude, p.Longitude)).ToList(), mapRef);
        }
    }

    protected async Task LoadAsync()
    {
        Model = await _activityRepository.GetActivityByUserIdAndActivityId(new Protos.Activities.UserIdAndActivityId { UserId = UserId, ActivityId = ActivityId }, CancellationToken.None);

        await PolylineFactory.CreateAndAddToMap(Model.Positions.Select(p => new LatLng(p.Latitude, p.Longitude)).ToList(), mapRef);

        StateHasChanged();
    }
}
