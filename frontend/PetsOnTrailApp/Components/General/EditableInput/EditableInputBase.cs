using Microsoft.AspNetCore.Components;

namespace PetsOnTrailApp.Components.General.EditableInput;

public class EditableInputBase : ComponentBase
{
    [Parameter] public object Value { get; set; }
    [Parameter] public InputType Type { get; set; } = InputType.Text;

    protected DateTimeOffset? DateValue => Type == InputType.Date ? Value as DateTimeOffset? : null;

    protected override void OnInitialized()
    {
        base.OnInitialized();
    }

    protected void OnInput(ChangeEventArgs e)
    {
        Value = e.Value;
    }

    protected void OnDateInput(ChangeEventArgs e)
    {
        if (DateTimeOffset.TryParse(e.Value.ToString(), out var date))
        {
            Value = date;
        }
    }

    public enum InputType
    {
        Text,
        Number,
        Date
    }
}
