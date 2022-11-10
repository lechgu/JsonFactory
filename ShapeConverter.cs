using System.Text.Json;
using System.Text.Json.Serialization;

namespace JsonFactory;

public class ShapeConverter : JsonConverter<Shape>
{

    public override bool CanConvert(Type type) => typeof(Shape).IsAssignableFrom(type);


    public override Shape Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options)
    {
        var dict = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(ref reader);
        var shape = dict["shape"].ToString();
        return shape switch
        {
            "circle" => Circle.FromJson(dict),
            "rectangle" => Rectangle.FromJson(dict),
            _ => null,
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        Shape value,
        JsonSerializerOptions _)
    {
        writer.WriteStartObject();

        writer.WriteString("shape", value.GetType().Name.ToLowerInvariant());
        value.WriteProperties(writer);
        writer.WriteEndObject();
    }
}