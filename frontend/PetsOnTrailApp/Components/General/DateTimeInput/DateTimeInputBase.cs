using Microsoft.AspNetCore.Components;

namespace PetsOnTrailApp.Components.General.DateTimeInput;

public class DateTimeInputBase : ComponentBase
{
    [Parameter] public DateTimeOffset? Value { get; set; } = null;

    protected override void OnInitialized()
    {
        base.OnInitialized();
    }

    protected string inputValue;

    protected void FormatInput(ChangeEventArgs e)
    {
        if (inputValue.Length == 4 && int.TryParse(inputValue, out int parsedValueHhMm))
        {
            int hours = parsedValueHhMm / 100;
            int minutes = parsedValueHhMm % 100;

            DateTime now = DateTime.UtcNow;
            Value = new DateTimeOffset(new DateTime(now.Year, now.Month, now.Day, hours, minutes, 0, DateTimeKind.Utc));
        }
        else if (inputValue.Length == 6 && int.TryParse(inputValue, out int parsedValueDdHhMm))
        {
            int day = parsedValueDdHhMm / 10000;
            int hours = (parsedValueDdHhMm % 10000) / 100;
            int minutes = parsedValueDdHhMm % 100;

            DateTime now = DateTime.UtcNow;
            Value = new DateTimeOffset(new DateTime(now.Year, now.Month, day, hours, minutes, 0, DateTimeKind.Utc));
        }
        else
        {
            // Handle invalid input or reset the formatted date
            Value = DateTimeOffset.MinValue;
        }
    }
}
