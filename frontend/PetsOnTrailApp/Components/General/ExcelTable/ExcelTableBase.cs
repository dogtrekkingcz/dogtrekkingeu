using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;

namespace PetsOnTrailApp.Components.General.ExcelTable;

public class ExcelTableBase : ComponentBase
{
    [Inject] protected IJSRuntime JSRuntime { get; set; }

    protected List<ColumnDefinition> Columns = new List<ColumnDefinition>
    {
        new ColumnDefinition { Header = "Name", Width = 150 },
        new ColumnDefinition { Header = "Age", Width = 100 },
        new ColumnDefinition { Header = "Country", Width = 200 }
    };

    protected List<Dictionary<string, object>> Data = new List<Dictionary<string, object>>
    {
        new Dictionary<string, object> { { "Name", "John Doe" }, { "Age", 30 }, { "Country", "USA" } },
        new Dictionary<string, object> { { "Name", "Jane Smith" }, { "Age", 25 }, { "Country", "UK" } },
        new Dictionary<string, object> { { "Name", "Samuel Johnson" }, { "Age", 35 }, { "Country", "Canada" } }
    };

    private bool isResizing = false;
    private ColumnDefinition resizingColumn;
    private double startX;
    private double startWidth;

    protected void OnMouseDown(MouseEventArgs e, ColumnDefinition column)
    {
        isResizing = true;
        resizingColumn = column;
        startX = e.ClientX;
        startWidth = column.Width;
        StateHasChanged();
    }

    protected void OnMouseMove(MouseEventArgs e)
    {
        if (isResizing && resizingColumn != null)
        {
            var newWidth = startWidth + (e.ClientX - startX);
            if (newWidth > 30) // Minimum column width
            {
                resizingColumn.Width = newWidth;
                StateHasChanged();
            }
        }
    }

    protected void OnMouseUp(MouseEventArgs e)
    {
        isResizing = false;
        resizingColumn = null;
        StateHasChanged();
    }

    protected void HideColumn(ColumnDefinition column)
    {
        column.Hidden = true;
        StateHasChanged();
    }

    public void Dispose()
    {
        // Unsubscribe from mouse events
        // Ensure proper cleanup
    }

    protected override void OnInitialized()
    {
        base.OnInitialized();
        // Subscribe to mouse events
        var dotNetRef = DotNetObjectReference.Create(this);
        JSRuntime.InvokeVoidAsync("addMouseEvents", dotNetRef);
    }

    [JSInvokable]
    public void OnMouseMoveJS(MouseEventArgs e) => OnMouseMove(e);

    [JSInvokable]
    public void OnMouseUpJS(MouseEventArgs e) => OnMouseUp(e);

    public class ColumnDefinition
    {
        public string Header { get; set; }
        public double Width { get; set; }
        public bool Hidden { get; set; }
    }
}
