namespace DogtrekkingCzApp.Models;

public record InputTimeModel
{
    public bool IsValid { get; set; } = false;

    private Google.Type.DateTime _value { get; set; }
    
    public Google.Type.DateTime Value
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