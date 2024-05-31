namespace Routers;

/// <summary>
/// Class that implements edge of graph.
/// </summary>
public class Edge
    {
        /// <summary>
        /// Edge of the graph.
        /// </summary>
        /// <param name="firstVertex">One of the two vertices of the edge.</param>
        /// <param name="secondVertex">One of the two vertices of the edge.</param>
        /// <param name="weight">Weight of the edge of the graph.</param>
        public Edge(int firstVertex, int secondVertex, int weight)
        {
            FirstVertex = firstVertex;
            SecondVertex = secondVertex;
            Weight = weight;
        }

        public int FirstVertex { get; }

        public int SecondVertex { get; }

        public int Weight { get; }
    }