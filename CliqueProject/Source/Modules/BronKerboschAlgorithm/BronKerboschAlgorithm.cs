using CliqueProject.Source.Defs.GraphRepresentation;

namespace CliqueProject.Source.Modules.BronKerboschAlgorithm;

public class BronKerboschAlgorithm
{ 
    public List<HashSet<int>> FindMaxCliques(BasicRepresentation graph)
    {
        HashSet<int> graphVertices = new(Enumerable.Range(0, graph.VerticesCount));
        List<HashSet<int>> cliques = new();
        RecursiveFunc(
            currentClique: new HashSet<int>(),
            candidateSet: graphVertices,
            exclusionSet: new HashSet<int>(),
            graph: graph,
            cliques: cliques);
        
        return cliques;
    }

    private void RecursiveFunc(
        HashSet<int> currentClique,
        HashSet<int> candidateSet,
        HashSet<int> exclusionSet,
        BasicRepresentation graph,
        List<HashSet<int>> cliques)
    {
        if (candidateSet.Count == 0 && exclusionSet.Count == 0)
        {
            cliques.Add(currentClique);
        }
        else
        {
            foreach (int vertex in candidateSet)
            {
                HashSet<int> newClique = new(currentClique) { vertex };
                
                HashSet<int> newCandidates = new(
                    candidateSet.Intersect(graph.GetVertexNeighbors(vertex))
                    );
                HashSet<int> newExclusion = new(
                    exclusionSet.Intersect(graph.GetVertexNeighbors(vertex))
                    );

                RecursiveFunc(newClique, newCandidates, newExclusion, graph, cliques);

                candidateSet.Remove(vertex);
                exclusionSet.Add(vertex);
            }
        }
    }
}