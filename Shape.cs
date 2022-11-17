using System.Text.Json;

namespace JsonFactory;

public abstract class Shape
{
    internal abstract void WriteProperties(Utf8JsonWriter writer);
}

public class ShapeJsonHandler : IJsonHandler
{
    public bool TryRead(Utf8JsonReader reader, Dictionary<string, JsonElement> dict, JsonSerializerOptions opts, out object obj)
    {
        obj = null;
        return false;
    }

    public void Write(Utf8JsonWriter writer, object obj, JsonSerializerOptions opts)
    {
        writer.WriteStartObject();
        writer.WriteEndObject();
    }
}
