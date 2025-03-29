using CliqueProject.Source.Defs.Generation;

namespace CliqueProject.Source.Defs.GraphRepresentation;

public class ListRepresentation : BasicRepresentation
{
    public List<HashSet<int>> List = new();
    public ListRepresentation(GraphGenerationOptions options) : base(options)
    {
        for (int i = 0; i < options.VerticesCount; i++)
        {
            List.Add(new HashSet<int>());
        }
        
        Random random = new();
        
        for (int i = 0; i < options.VerticesCount; i++)
        {
            for (int j = 0; j < options.VerticesCount; j++)
            {
                if(i >= j)
                    continue; // Skipping diagonal and symmetrical coordinates 
                
                bool hasEdge = random.NextSingle() < options.Density;

                if (hasEdge)
                {
                    List[i].Add(j);
                    List[j].Add(i);
                    EdgesCount++;
                }
            }
        }
    }

    public override bool HasConnection(int vertexA, int vertexB) => List[vertexA].Contains(vertexB);
    public override IEnumerable<int> GetVertexNeighbors(int vertexA)
    {
        if(vertexA < 0 || vertexA >= VerticesCount)
            throw new ArgumentException("Vertex id is out of allowed range");
        
        for (int neighbour = 0; neighbour < VerticesCount; neighbour++)
        {
            if(vertexA == neighbour)
                continue;
            
            if(List[vertexA].Contains(neighbour))
                yield return neighbour;
        }
    }
}