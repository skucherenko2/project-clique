using System.Diagnostics;
using CliqueProject.Source.Defs.Generation;
using CliqueProject.Source.Modules.BronKerboschAlgorithm;
using CliqueProject.Source.Utilities;

Stopwatch stopwatch = new Stopwatch();
stopwatch.Start();

float density = 0.3f;
GraphGenerationOptions options = new(200, density) {RandomSeed = 42};

var graph = options.ToGraph(useMatrix: true);
// Also can be called like this:
// var graph = options.ToListRepresentation().ToGraph();
// var graph = options.ToMatrixRepresentation().ToGraph();

Console.WriteLine($"Generated edges: {graph.Representation.EdgesCount}");
Console.WriteLine($"Max edges: {options.MaxPossibleEdges}");
Console.WriteLine($"Density: {(float)graph.Representation.EdgesCount / options.MaxPossibleEdges:F4}");
Console.WriteLine($"Expected density: {density}");

var algorithm = new BronKerboschAlgorithm();
var result = algorithm.FindMaxCliques(graph.Representation);
int maxCliqueSize = result.Max(set => set.Count);

foreach (var clique in result.Where(clique => clique.Count == maxCliqueSize))
{
    Console.WriteLine(string.Join(" ,", clique));
}

stopwatch.Stop();
Console.WriteLine($"Час виконання: {stopwatch.Elapsed}");