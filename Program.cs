using System.Text.Json;
using JsonFactory;

// var json = """
// [
//   {
//     "shape": "circle",
//     "radius": 42
//   },
//   {
//     "shape": "rectangle",
//     "width": 25,
//     "height": 17
//   }
// ]
// """;

var opts = new JsonSerializerOptions
{
    WriteIndented = true,

    Converters = { new UniversalConverter() }
};

// var shapes = JsonSerializer.Deserialize<Shape[]>(json, opts);
// foreach (var shape in shapes)
// {
//     Console.WriteLine(shape);
// }

// var shapes = new object[] { Circle.WithRadius(42), Rectangle.WithWidthAndHeight(25, 17) };
// var json = JsonSerializer.Serialize(shapes, opts);
// Console.WriteLine(json);

// var shapes2 = JsonSerializer.Deserialize<Shape[]>(json, opts);
// foreach (var shape in shapes2)
// {
//     Console.WriteLine(shape);
// }

var geometry = new Geometry();
var json = JsonSerializer.Serialize(geometry, opts);
Console.WriteLine(json);

var c = JsonSerializer.Deserialize<Geometry>(json, opts);
Console.WriteLine(c.Shape1);
Console.WriteLine(c.Shape2);
Console.WriteLine($"# of extra shapes: {c.ExtraShapes.Length}");