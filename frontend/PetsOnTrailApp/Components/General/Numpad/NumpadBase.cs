using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace PetsOnTrailApp.Components.General.Numpad;

public class NumpadBase : ComponentBase
{
    [Inject] protected IJSRuntime JSRuntime { get; set; }

    protected override void OnInitialized()
    {
        base.OnInitialized();
    }

    private ElementReference currentInput;
    private string currentValue;

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            await JSRuntime.InvokeVoidAsync("initializeNumpad", DotNetObjectReference.Create(this));
        }
    }

    [JSInvokable]
    public void ShowNumpad(ElementReference input)
    {
        currentInput = input;
        currentValue = "";
        StateHasChanged();
    }

    protected void AppendNumber(string number)
    {
        currentValue += number;
        JSRuntime.InvokeVoidAsync("updateInputValue", currentInput, currentValue);
    }

    protected void Cancel()
    {
        currentValue = "";
        JSRuntime.InvokeVoidAsync("updateInputValue", currentInput, currentValue);
        CloseNumpad();
    }

    protected void OK()
    {
        JSRuntime.InvokeVoidAsync("updateInputValue", currentInput, currentValue);
        CloseNumpad();
    }

    protected void CloseNumpad()
    {
        JSRuntime.InvokeVoidAsync("hideNumpad");
    }
}
