using System.Text.Json;

namespace JsonFactory;

public class PickyGeometry
{
    private readonly Circle circle;
    private readonly Rectangle rectangle;

    public PickyGeometry(Circle circle, Rectangle rectangle)
    {
        this.circle = circle;
        this.rectangle = rectangle;
    }

    public Circle Circle
    {
        get => circle;
    }

    public Rectangle Rectangle
    {
        get => rectangle;
    }
}

public class PickyGeometryJsonHandler : IJsonHandler
{
    public bool TryRead(Utf8JsonReader reader, Dictionary<string, JsonElement> dict, out object obj)
    {
        throw new NotImplementedException();
    }

    public void Write(Utf8JsonWriter writer, object obj, JsonSerializerOptions opts)
    {
        var pickyGeometry = obj as PickyGeometry;
        writer.WritePropertyName("circle");
        JsonSerializer.Serialize(writer, pickyGeometry.Circle, typeof(Circle), opts);
        writer.WritePropertyName("rectangle");
        JsonSerializer.Serialize(writer, pickyGeometry.Rectangle, typeof(Rectangle), opts);
    }
}