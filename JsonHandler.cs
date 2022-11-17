using System.Text.Json;

namespace JsonFactory;

public interface IJsonHandler
{
    public void Write(Utf8JsonWriter writer, object obj, JsonSerializerOptions opts);

    public bool TryRead(Utf8JsonReader reader, Dictionary<string, JsonElement> dict, out object obj);
}
