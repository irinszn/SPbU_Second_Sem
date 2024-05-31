namespace Routers;

using System.Text;

/// <summary>
/// Class that implements topology transformation.
/// </summary>
public static class TopologyConversion
{
    /// <summary>
    /// Mathod that transform string from input file to array of edge of the graph.
    /// </summary>
    /// <param name="topology">Topology from input file.</param>
    /// <returns>Array of the edge and number of vertices.</returns>
    public static (Edge[], int) ReadTopology(string topology)
    {
        var vertices = new HashSet<int>();
        var edges = new List<Edge>();

        foreach (var line in topology.Split("\n"))
        {
            var elements = line.Split(":");

            if (elements.Length != 2)
            {
                throw new ArgumentException("Incorrect topology");
            }

            var vertex = elements[0];
            var connectedVertices = elements[1].Split(",");

            if (!int.TryParse(vertex, out var firstVertex))
            {
                throw new ArgumentException("Incorrect topology");
            }

            vertices.Add(firstVertex);

            foreach (var element in connectedVertices)
            {
                var vertexWithBandwidth = element.Replace("(", "").Replace(")", "").Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (vertexWithBandwidth.Length != 2)
                {
                    throw new ArgumentException("Incorrect topology");
                }

                vertex = vertexWithBandwidth[0];

                if (!int.TryParse(vertex, out var secondVertex))
                {
                    throw new ArgumentException("Incorrect topology");
                }

                vertices.Add(secondVertex);

                var edgeWeight = int.Parse(vertexWithBandwidth[1]);

                if (edgeWeight < 0)
                {
                    throw new ArgumentException("Bandwidth can't be negative");
                }

                edges.Add(new Edge(firstVertex, secondVertex, edgeWeight));
            }
        }

        return (edges.ToArray(), vertices.Count);
    }

    /// <summary>
    /// Method that transform array of edge to string.
    /// </summary>
    /// <param name="optimalConfiguration">Array of edge from optimal configuration.</param>
    /// <returns>Optimal configuration in the desired format.</returns>
    public static string PrintTopology(Edge[] optimalConfiguration)
    {
        var result = new List<string>();

        foreach (var edge in optimalConfiguration)
        {
            var newLine = $"{edge.FirstVertex} : {edge.SecondVertex} ({edge.Weight})";

            result.Add(newLine + '\n');
        }

        result.Sort();

        var sortedResult = new StringBuilder();

        foreach (var element in result)
        {
            sortedResult.Append(element);
        }

        return sortedResult.ToString();
    }
}