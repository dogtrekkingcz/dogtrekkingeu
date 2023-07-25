using Newtonsoft.Json;

namespace DogsOnTrailApp.Extensions;

public static class ObjectExtensions
{
    public static string Dump(this object obj)
    {
        return JsonConvert.SerializeObject(obj);
    }
}