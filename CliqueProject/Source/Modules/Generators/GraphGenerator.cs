using CliqueProject.Source.Defs.Generation;
using CliqueProject.Source.Defs.Graph;
using CliqueProject.Source.Defs.GraphRepresentation;

namespace CliqueProject.Source.Modules.Generators;

public static class GraphGenerator
{
    public static Graph GenerateGraph(GraphGenerationOptions options, bool useMatrix)
    {
        BasicRepresentation representation;

        if (useMatrix) representation = new MatrixRepresentation(options);
        
        else representation = new ListRepresentation(options);
        
        Graph graph = new(representation);
        
        return graph;
    }
}