namespace DogsOnTrailApp.Models;

public record InputTimeSpanModel
{
    public bool IsValid { get; set; } = false;

    private Google.Protobuf.WellKnownTypes.Timestamp _value { get; set; }
    
    public Google.Protobuf.WellKnownTypes.Timestamp Value
    {
        get
        {
            return _value;
        }
        set
        {
            if (value == null)
            {
                IsValid = false;
            } 
            else 
            {
                IsValid = true;
                _value = value;
            }
        }
    }
}