using CliqueProject.Source.Defs.Generation;

namespace CliqueProject.Source.Defs.GraphRepresentation;

public class MatrixRepresentation : BasicRepresentation
{
    public bool[,] Matrix;
    public MatrixRepresentation(GraphGenerationOptions options) : base(options)
    {
        Matrix = new bool[options.VerticesCount, options.VerticesCount];
        Random random = new();
        
        for (int i = 0; i < options.VerticesCount; i++)
        {
            for (int j = 0; j < options.VerticesCount; j++)
            {
                if(i >= j)
                    continue; // Skipping diagonal and symmetrical coordinates 
                
                bool hasEdge = random.NextSingle() < options.Density;
                
                Matrix[i, j] = hasEdge;
                Matrix[j, i] = hasEdge;

                if (hasEdge)
                    EdgesCount++;
            }
        }
    }
    public override bool HasConnection(int vertexA, int vertexB) => Matrix[vertexA, vertexB];
    public override IEnumerable<int> GetVertexNeighbors(int vertexA)
    {
        if(vertexA < 0 || vertexA >= VerticesCount)
            throw new ArgumentException("Vertex id is out of allowed range");

        for (int neighbour = 0; neighbour < VerticesCount; neighbour++)
        {
            if(vertexA == neighbour)
                continue;
            
            if(Matrix[vertexA, neighbour])
                yield return neighbour;
        }
    }
}