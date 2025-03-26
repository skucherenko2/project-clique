using CliqueProject.Source.Defs.Generation;
using CliqueProject.Source.Defs.Graph;
using CliqueProject.Source.Defs.GraphRepresentation;
using CliqueProject.Source.Modules.Generators;

namespace CliqueProject.Source.Utilities;

public static class ConversionUtilities
{
    public static Graph ToGraph(this GraphGenerationOptions representation, bool useMatrix)
    {
        return GraphGenerator.GenerateGraph(representation, useMatrix);
    }
    public static Graph ToGraph(this BasicRepresentation representation)
    {
        return new Graph(representation);
    }

    public static ListRepresentation ToListRepresentation(this GraphGenerationOptions options)
    {
        return new ListRepresentation(options);
    }

    public static MatrixRepresentation ToMatrixRepresentation(this GraphGenerationOptions options)
    {
        return new MatrixRepresentation(options);
    }
}