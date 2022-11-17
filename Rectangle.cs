using System.Text.Json;

namespace JsonFactory;



public class Rectangle : Shape
{
    readonly int width;
    readonly int height;

    public int Width
    {
        get => width;
    }

    public int Height
    {
        get => height;
    }

    Rectangle(int width, int height)
    {
        this.width = width;
        this.height = height;
    }

    public override string ToString() => $"I am a rectangle {width} by {height}";

    internal override void WriteProperties(Utf8JsonWriter writer)
    {
        writer.WriteNumber("width", width);
        writer.WriteNumber("height", height);
    }

    public static Rectangle WithWidthAndHeight(int width, int height)
    {
        return new Rectangle(width, height);
    }

    public static Rectangle FromJson(Dictionary<string, JsonElement> dict)
    {
        if (dict["width"].TryGetInt32(out int width) && dict["height"].TryGetInt32(out int height))
        {
            return WithWidthAndHeight(width, height);
        }
        return null;
    }
}

public class RectangleJsonHandler : IJsonHandler
{
    public bool TryRead(Utf8JsonReader reader, Dictionary<string, JsonElement> dict, out object obj)
    {
        var widthElem = dict.GetValueOrDefault("width");
        var heightElem = dict.GetValueOrDefault("height");
        if (widthElem.ValueKind == JsonValueKind.Number && heightElem.ValueKind == JsonValueKind.Number)
        {
            if (widthElem.TryGetInt32(out int width) && heightElem.TryGetInt32(out int height))
            {
                obj = Rectangle.WithWidthAndHeight(width, height);
                return true;
            }
        }
        obj = null;
        return false;
    }

    public void Write(Utf8JsonWriter writer, object obj, JsonSerializerOptions opts)
    {
        var rect = obj as Rectangle;
        writer.WriteNumber("width", rect.Width);
        writer.WriteNumber("height", rect.Height);
    }
}