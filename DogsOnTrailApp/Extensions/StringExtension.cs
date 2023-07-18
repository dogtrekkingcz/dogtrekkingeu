namespace DogsOnTrailApp.Extensions;

public static class StringExtension
{
    public static Guid ToGuid(this string src)
    {
        Guid ret = Guid.Empty;

        if (Guid.TryParse(src, out ret))
            return ret;
        
        return ret;
    }
}