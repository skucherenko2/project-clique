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

                if (hasEdge)
                    EdgesCount++;
            }
        }
    }
    public override bool HasConnection(int vertexA, int vertexB) => Matrix[vertexA, vertexB];
}