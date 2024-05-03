using FisSst.BlazorMaps;
using Microsoft.AspNetCore.Components;
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

    [Inject] private IMarkerFactory MarkerFactory { get; init; }

    protected FisSst.BlazorMaps.Map mapRef;
    protected MapOptions mapOptions = new MapOptions()
    {
        DivId = "mapId",
        Center = new LatLng(50.279133, 18.685578),
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

    public ActivityModel Model = null;

    protected async override void OnInitialized()
    {
        base.OnInitialized();

        Model = await _activityRepository.GetActivityByUserIdAndActivityId(new Protos.Activities.UserIdAndActivityId { UserId = UserId, ActivityId = ActivityId }, CancellationToken.None);

        Console.WriteLine($"ActivityViewBase.OnInitialized: Model is: {Model.Dump()}");

        StateHasChanged();
    }
}
