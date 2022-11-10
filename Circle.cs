using System.Text.Json;

namespace JsonFactory;

class Circle : Shape
{
    readonly int radius;

    Circle(int radius)
    {
        this.radius = radius;
    }

    public override string ToString() => $"I am a circle with radius {radius}";

    internal override void WriteProperties(Utf8JsonWriter writer)
    {
        writer.WriteNumber("radius", radius);
    }

    public static Circle WithRadius(int radius)
    {
        return new Circle(radius);
    }

    public static Circle FromJson(Dictionary<string, JsonElement> dict)
    {
        if (dict["radius"].TryGetInt32(out int radius))
        {
            return WithRadius(radius);
        }
        return null;
    }
}