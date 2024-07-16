using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;

namespace PetsOnTrailApp.Components.General.ExcelTable;

public class ExcelTableBase : ComponentBase
{
    private static Guid _column1Id = Guid.Parse("fa17345a-8acb-47d6-aa40-31924c176641");
    private static Guid _column2Id = Guid.Parse("18d833aa-0ef8-4f6a-9e31-18586ebb5569");
    private static Guid _column3Id = Guid.Parse("e72e1802-2ef0-4a0c-8a02-ef2c7991a87e");

    [Inject] protected IJSRuntime JSRuntime { get; set; }

    protected List<ColumnDefinition> Columns = new List<ColumnDefinition>
    {
        new ColumnDefinition { Id = _column1Id, Header = "Name", Width = 150 },
        new ColumnDefinition { Id = _column2Id, Header = "Age", Width = 100 },
        new ColumnDefinition { Id = _column3Id, Header = "Country", Width = 200 }
    };

    protected List<Dictionary<Guid, object>> Data = new List<Dictionary<Guid, object>>
    {
        new Dictionary<Guid, object> { { _column1Id, "John Doe" }, { _column2Id, 30 }, { _column3Id, "USA" } },
        new Dictionary<Guid, object> { { _column1Id, "Jane Smith" }, { _column2Id, 25 }, { _column3Id, "UK" } },
        new Dictionary<Guid, object> { { _column1Id, "Samuel Johnson" }, { _column2Id, 35 }, { _column3Id, "Canada" } }
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

    protected void ShowColumn(ColumnDefinition column)
    {
        column.Hidden = false;

        StateHasChanged();
    }

    protected void SortBy(ColumnDefinition column)
    {
        foreach (var col in Columns)
        {
            col.SortBy = false;
            col.SortByDescending = false;
        }

        column.SortBy = true;
        column.SortByDescending = !column.SortByDescending;

        Data = column.SortByDescending
            ? Data.OrderByDescending(row => row[column.Id]).ToList()
            : Data.OrderBy(row => row[column.Id]).ToList();

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
        public Guid Id { get; set; } = Guid.Empty;
        public string Header { get; set; }
        public double Width { get; set; }
        public bool Hidden { get; set; } = false;
        public bool SortBy { get; set; } = false;
        public bool SortByDescending { get; set; } = false;
    }
}
