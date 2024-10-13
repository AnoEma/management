using System.Text;
using System.Text.Json;

namespace Infrastructure.Extensions;

public static class JsonHttpContentSerializationExtension
{
    public static StringContent SerializeRequest(this object request, string application)
    {
        var json = JsonSerializer.Serialize(request);
        return new StringContent(json, Encoding.UTF8, application);
    }

    public static string Serialize(this object request)
    {
        return JsonSerializer.Serialize(request);
    }
}
