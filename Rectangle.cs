using System.Text.Json;

namespace JsonFactory;



class Rectangle : Shape
{
    readonly int width;
    readonly int height;

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