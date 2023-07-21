namespace Storage.Extensions;

public static class StringExtensions
{
    public static Guid ToGuid(this string src)
    {
        Guid ret = Guid.Empty;

        Guid.TryParse(src, out ret);
        
        return ret;
    }
}