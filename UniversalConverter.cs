using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace JsonFactory;

public class UniversalConverter : JsonConverter<object>
{
    private readonly static Dictionary<Type, IJsonHandler> knownWriters = new()
    {
        { typeof(Shape), new ShapeJsonHandler()},
        { typeof(Circle), new CircleJsonHandler()},
        { typeof(Rectangle), new RectangleJsonHandler()}
    };

    private readonly static Dictionary<string, IJsonHandler> knownReaders = knownWriters.ToDictionary(x => x.Key.ToString(), x => x.Value);

    public override bool CanConvert(Type type) => knownWriters.ContainsKey(type);


    public override object Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options)
    {
        var dict = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(ref reader);
        var typeName = dict["__type"].ToString();
        var jsonHandler = knownReaders.GetValueOrDefault(typeName);
        if (jsonHandler is not null)
        {
            if (jsonHandler.TryRead(reader, dict, out var obj))
            {
                return obj;
            }
        }
        return null;
    }

    public override void Write(
        Utf8JsonWriter writer,
        object obj,
        JsonSerializerOptions opts)
    {

        writer.WriteStartObject();

        writer.WriteString("__type", obj.GetType().ToString());
        var handler = knownWriters.GetValueOrDefault(obj.GetType());
        handler?.Write(writer, obj, opts);
        writer.WriteEndObject();
    }
}