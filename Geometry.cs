namespace JsonFactory;

public class Geometry
{
    public Geometry()
    {

    }
    public Shape Shape1 { get; set; } = Circle.WithRadius(42);
    public Shape Shape2 { get; set; } = Rectangle.WithWidthAndHeight(17, 25);
    public Shape[] ExtraShapes { get; set; } = new[] { Circle.WithRadius(1) };
}