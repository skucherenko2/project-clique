using CliqueProject.Source.Defs.Generation;
using CliqueProject.Source.Utilities;



float density = 0.01f;
GraphGenerationOptions options = new(100, density);

var graph = options.ToGraph(useMatrix: true);
// Also can be called like this:
// var graph = options.ToListRepresentation().ToGraph();
// var graph = options.ToMatrixRepresentation().ToGraph();

Console.WriteLine($"Generated edges: {graph.Representation.EdgesCount}");
Console.WriteLine($"Max edges: {options.MaxPossibleEdges}");
Console.WriteLine($"Density: {(float)graph.Representation.EdgesCount / options.MaxPossibleEdges:F4}");
Console.WriteLine($"Expected density: {density}");

