using CliqueProject.Source.Utilities;

namespace CliqueProject.Source.Defs.Generation;

public class GraphGenerationOptions
{
    public int VerticesCount { get; }
    public float Density { get; }

    public int MaxPossibleEdges => VerticesCount * (VerticesCount - 1) / 2;

    public GraphGenerationOptions(int verticesCount, float density)
    {
        if(verticesCount <= 0)
            throw new ArgumentException("Vertices count must be positive");
        
        if(density < 0 || density > 1)
            throw new ArgumentException("Density must be between 0 and 1");
        
        VerticesCount = verticesCount;
        Density = density;
    }
}