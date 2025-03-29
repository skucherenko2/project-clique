using CliqueProject.Source.Defs.Generation;
using CliqueProject.Source.Utilities;



float density = 0.1f;
GraphGenerationOptions options = new(100, density);

var graph = options.ToGraph(useMatrix: true);
// Also can be called like this:
// var graph = options.ToListRepresentation().ToGraph();
// var graph = options.ToMatrixRepresentation().ToGraph();

Console.WriteLine($"Generated edges: {graph.Representation.EdgesCount}");
Console.WriteLine($"Max edges: {options.MaxPossibleEdges}");
Console.WriteLine($"Density: {(float)graph.Representation.EdgesCount / options.MaxPossibleEdges:F4}");
Console.WriteLine($"Expected density: {density}");

for (int i = 0; i < graph.Representation.VerticesCount; i++)
{
    string neighbors = "";
    int count = 0;

    foreach (var neighbor in graph.Representation.GetVertexNeighbors(i))
    {
        neighbors += neighbor + ", ";
        count++;
    }
    
    Console.WriteLine(i + " : " + $"({count}) " + neighbors);
}