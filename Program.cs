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
    Converters = { new ShapeConverter() }
};

var shapes = JsonSerializer.Deserialize<Shape[]>(json, opts);
foreach (var shape in shapes)
{
    Console.WriteLine(shape);
}

