namespace JsonFactory;

public class ComplexObject
{
    public ComplexObject()
    {

    }
    public Shape Shape1 { get; set; } = Circle.WithRadius(42);
    public Shape Shape2 { get; set; } = Rectangle.WithWidthAndHeight(17, 25);
}