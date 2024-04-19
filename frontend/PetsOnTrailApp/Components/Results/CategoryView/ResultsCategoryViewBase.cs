using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using PetsOnTrailApp.Shared.ResourceFiles;

namespace PetsOnTrailApp.Components.Results.CategoryView;

public class ResultsCategoryViewBase : ComponentBase
{
    [Parameter] public string ActionId { get; set; } = string.Empty;
    [Parameter] public string RaceId { get; set; } = string.Empty;
    [Parameter] public string CategoryId { get; set; } = string.Empty;

    [Inject]
    public IStringLocalizer<Resource> Localizer { get; set; }


    protected override void OnInitialized()
    {
        base.OnInitialized();


    }
}
