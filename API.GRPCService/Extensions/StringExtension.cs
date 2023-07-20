namespace DogsOnTrailGRPCService.Extensions;

public static class StringExtension
{
    public static Guid ToGuid(this string id)
    {
        Guid ret = Guid.Empty;

        Guid.TryParse(id, out ret);
        
        return ret;
    }
}