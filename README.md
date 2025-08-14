Bron–Kerbosch Algorithm (maximum clique search in a graph)

Team  


	•	Shon Kucherenko  
	•	Yuliia Mala  
	•	Olena Zinchuk  

Formal description
Algorithm description
The Bron–Kerbosch algorithm is designed to find the maximal complete subgraphs of a given undirected graph. A maximal complete subgraph (clique) is a complete subgraph that is not contained in any other complete subgraph.

Pseudocode
Notation:

R – current clique
P – set of candidates for clique expansion
X – set of vertices to exclude from consideration as they have already been processed in previous steps

Initial function call input data:
R = ∅ (empty set)
P = V (set of all vertices of the graph)
X = ∅ (empty set)

Algorithm pseudocode:

<img width="459" height="216" alt="image" src="https://github.com/user-attachments/assets/f227c4a4-7d7e-4652-b4f1-f69c363e4cff" />


Technical implementation
The implementation was done in C#.

For implementing separate graph representations, an abstract class BasicRepresentation was created, which defines the methods required for the task. For specific graph representations, two classes were created: ListRepresentation and MatrixRepresentation, which implement the methods defined in BasicRepresentation.

Given the specifics of the chosen algorithm (a large number of set operations), for adjacency list representation we used the following structure: List<HashSet<int>>.

For edge generation, for each edge we called a random value function and compared it with the desired density:

random.NextSingle() < options.Density

We consider undirected graphs, so at the generation stage, edges are set only for half of the adjacency matrix, and the rest are obtained by symmetry.
