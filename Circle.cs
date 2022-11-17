using System.Text.Json;

namespace JsonFactory;

public class Circle : Shape
{
    readonly int radius;

    Circle(int radius)
    {
        this.radius = radius;
    }

    public int Radius
    {
        get => radius;
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

public class CircleJsonHandler : IJsonHandler
{
    public bool TryRead(Utf8JsonReader reader, Dictionary<string, JsonElement> dict, out object obj)
    {
        var radiusElem = dict.GetValueOrDefault("radius");
        if (radiusElem.ValueKind == JsonValueKind.Number)
        {
            if (radiusElem.TryGetInt32(out int radius))
            {
                obj = Circle.WithRadius(radius);
                return true;
            }
        }
        obj = null;
        return false;
    }

    public void Write(Utf8JsonWriter writer, object obj, JsonSerializerOptions opts)
    {
        var circle = obj as Circle;
        writer.WriteNumber("radius", circle.Radius);
    }
}