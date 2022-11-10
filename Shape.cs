using System.Text.Json;

namespace JsonFactory;

public abstract class Shape
{
    internal abstract void WriteProperties(Utf8JsonWriter writer);
}

