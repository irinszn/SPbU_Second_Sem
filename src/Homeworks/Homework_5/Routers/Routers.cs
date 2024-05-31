namespace Routers;

/// <summary>
/// Class that implements the construction of an optimal topology.
/// </summary>
public static class MakeTopology
{
    /// <summary>
    /// Method that build optimal topology using Prima's algorithm, throws exception if graph is not connected.
    /// </summary>
    /// <param name="topology">Input topology from the file.</param>
    /// <returns>Optimal topology.</returns>
    public static string BuildOptimalTopology(string topology)
    {
        if (topology == string.Empty)
        {
            throw new ArgumentException("Topology can't be empty");
        }

        (var edges, var vertexCount) = TopologyConversion.ReadTopology(topology);

        var optimalConfiguration = AlgorithmPrima(edges, vertexCount);

        if (optimalConfiguration.Length != vertexCount - 1)
        {
            throw new DisconnectedGraphException("The graph is not connected");
        }

        return TopologyConversion.PrintTopology(optimalConfiguration);
    }

    /// <summary>
    /// Method that implements Prima's algorithm.
    /// </summary>
    /// <param name="edges">Edges of the graph.</param>
    /// <param name="vertexCount">The number of vertices of the graph.</param>
    /// <returns>Maximum spanning tree.</returns>
    private static Edge[] AlgorithmPrima(Edge[] edges, int vertexCount)
    {
        var connectedVertices = new HashSet<int>() { 1 };
        var optimalConfiguration = new List<Edge>();

        while (connectedVertices.Count < vertexCount)
        {
            var maxEdge = FindMaxEdge(edges, connectedVertices);

            if (maxEdge.Weight == -1)
            {
                break;
            }

            optimalConfiguration.Add(maxEdge);
            connectedVertices.Add(maxEdge.FirstVertex);
            connectedVertices.Add(maxEdge.SecondVertex);
        }

        return optimalConfiguration.ToArray();
    }

    /// <summary>
    /// Method that find current edge with maximum weight.
    /// </summary>
    /// <param name="edges">Edges of the graph.</param>
    /// <param name="connectedVertices">Set of the connected vertices of the graph.</param>
    /// <returns>Edge with maximum weight.</returns>
    private static Edge FindMaxEdge(Edge[] edges, HashSet<int> connectedVertices)
    {
        var maxEdge = new Edge(0, 0, -1);

        foreach (var edge in edges)
        {
            if ((connectedVertices.Contains(edge.FirstVertex) || connectedVertices.Contains(edge.SecondVertex)) && !(connectedVertices.Contains(edge.FirstVertex) && connectedVertices.Contains(edge.SecondVertex)))
            {
                if (maxEdge.Weight < edge.Weight)
                {
                    maxEdge = edge;
                }
            }
        }

        return maxEdge;
    }
}