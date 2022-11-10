using System.Text.Json;
using JsonFactory;

var json = """
[
  {
    "shape": "circle",
    "radius": 42
  },
  {
    "shape": "rectangle",
    "width": 25,
    "height": 17
  }
]
""";

var opts = new JsonSerializerOptions
{
    WriteIndented = true,

    Converters = { new ShapeConverter() }
};

// var shapes = JsonSerializer.Deserialize<Shape[]>(json, opts);
// foreach (var shape in shapes)
// {
//     Console.WriteLine(shape);
// }


var complex = new ComplexObject();
json = JsonSerializer.Serialize(complex, opts);
Console.WriteLine(json);

var c = JsonSerializer.Deserialize<ComplexObject>(json, opts);
Console.WriteLine(c.Shape1);
Console.WriteLine(c.Shape2);