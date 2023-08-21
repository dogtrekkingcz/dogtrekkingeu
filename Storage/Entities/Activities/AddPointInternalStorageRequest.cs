namespace Storage.Entities.Activities;

public sealed record AddPointInternalStorageRequest
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public Guid ActivityId { get; set; } = Guid.Empty;

    public DateTimeOffset Time { get; set; } = DateTimeOffset.Now;
        
    public double Latitude { get; set; } = double.NaN;

    public double Longitude { get; set; } = double.NaN;

    public double Altitude { get; set; } = double.NaN;

    public double Accuracy { get; set; } = double.NaN;

    public double Course { get; set; } = double.NaN;

    public string Note { get; set; } = string.Empty;
}