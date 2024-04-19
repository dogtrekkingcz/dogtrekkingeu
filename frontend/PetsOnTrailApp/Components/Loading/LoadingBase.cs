using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using PetsOnTrailApp.Shared.ResourceFiles;

namespace PetsOnTrailApp.Components.Loading;

public class LoadingBase : ComponentBase
{
    [Inject] IStringLocalizer<Resource> Localizer { get; set; }
}
