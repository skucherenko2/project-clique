using System.Diagnostics;
using CliqueProject.Source.Defs.Generation;
using CliqueProject.Source.Defs.GraphRepresentation;
using CliqueProject.Source.Modules.BronKerboschAlgorithm;
using CliqueProject.Source.Utilities;
using CliqueProject.Source.Defs.Experiments;

class Program
{
    static void Main()
    {
        int[] sizes = [20, 40, 60, 80, 100, 120, 140, 160, 180, 200];
        float[] densities = [0.075f, 0.15f, 0.225f, 0.3f, 0.375f];
        int experimentsPerConfig = 20;
        
        List<ExperimentResult> results = [];

        foreach (int size in sizes)
        {
            foreach (float density in densities)
            {
                List<long> timesMatrix = [];
                List<long> timesList = [];
                List<int> maxCliquesMatrix = [];
                List<int> maxCliquesList = [];

                for (int i = 0; i < experimentsPerConfig; i++)
                {
                    GraphGenerationOptions options = new(size, density) { RandomSeed = i };
                    var graphList = options.ToListRepresentation().ToGraph();
                    var graphMatrix = options.ToMatrixRepresentation().ToGraph();
                    
                    (long timeMatrix, int maxCliqueMatrix) = RunExperiment(graphMatrix.Representation);
                    (long timeList, int maxCliqueList) = RunExperiment(graphList.Representation);
                    
                    timesMatrix.Add(timeMatrix);
                    timesList.Add(timeList);
                    maxCliquesMatrix.Add(maxCliqueMatrix);
                    maxCliquesList.Add(maxCliqueList);
                }
                Console.WriteLine($"Done experiments for size {size} and density{density}");
                results.Add(new ExperimentResult(size, density, "Matrix", timesMatrix.Average(), maxCliquesMatrix.Average()));
                results.Add(new ExperimentResult(size, density, "List", timesList.Average(), maxCliquesList.Average()));
            }
        }
        SaveResultsToCsv(results, "experiment_results.csv");
    }

    private static (long, int) RunExperiment(BasicRepresentation graph)
    {
        BronKerboschAlgorithm algorithm = new();
        Stopwatch stopwatch = Stopwatch.StartNew();
        var cliques = algorithm.FindMaxCliques(graph);
        stopwatch.Stop();

        int maxCliqueSize = cliques.Max(c => c.Count);

        return (stopwatch.ElapsedMilliseconds, maxCliqueSize);
    }

    static void SaveResultsToCsv(List<ExperimentResult> results, string filePath)
    {
        using StreamWriter writer = new(filePath);
        writer.WriteLine("GraphSize,Density,RepresentationType,ExecutionTimeMs,MaxCliqueSize");

        foreach (var result in results)
        {
            writer.WriteLine($"{result.GraphSize},{result.Density},{result.RepresentationType},{result.ExecutionTimeMs},{result.MaxCliqueSize}");
        }

        Console.WriteLine($"Results are saved in {filePath}");
    }
}



