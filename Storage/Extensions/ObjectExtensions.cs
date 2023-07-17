using Newtonsoft.Json;

namespace Storage.Extensions;

internal static class ObjectExtensions
{
    internal static string Dump(this object obj)
    {
        return JsonConvert.SerializeObject(obj);
    }
}