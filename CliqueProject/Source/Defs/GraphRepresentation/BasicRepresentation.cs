using CliqueProject.Source.Defs.Generation;

namespace CliqueProject.Source.Defs.GraphRepresentation;

public abstract class BasicRepresentation
{
    protected BasicRepresentation(GraphGenerationOptions options)
    {
        VerticesCount = options.VerticesCount;
    }

    public int VerticesCount;
    public int EdgesCount;
    public abstract bool HasConnection(int vertexA, int vertexB);
    public abstract IEnumerable<int> GetVertexNeighbors(int vertexA);
}