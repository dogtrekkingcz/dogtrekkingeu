namespace PetsOnTrail.Actions.Extensions;

internal static class StringExtensions
{
    public static Guid ToGuid(this string id)
    {
        Guid ret = Guid.Empty;

        if (Guid.TryParse(id, out ret))
            return ret;
        
        return Guid.Empty;
    }
}