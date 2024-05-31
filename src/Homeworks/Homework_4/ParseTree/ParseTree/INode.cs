namespace ParseTree;

/// <summary>
/// Interface of node in parse tree.
/// </summary>
public interface INode
{
    /// <summary>
    /// Calculate the value of subtree.
    /// </summary>
    /// <returns>Result of calculate.</returns>
    public float Calculate();

    /// <summary>
    /// Print subtree into console.
    /// </summary>
    /// <returns>Value of node.</returns>
    public string Print();
}