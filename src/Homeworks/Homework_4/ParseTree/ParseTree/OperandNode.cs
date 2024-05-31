namespace ParseTree;

/// <summary>
/// Class that implements node with operand.
/// </summary>
public class OperandNode : INode
{
    /// <summary>
    /// Value of operand node.
    /// </summary>
    public float Number { get; set; }

    /// <summary>
    /// Calculate the value of subtree.
    /// </summary>
    /// <returns>Result of calculate.</returns>
    public float Calculate() => Number;

    /// <summary>
    /// Print subtree into console.
    /// </summary>
    /// <returns>Value of node.</returns>
    public string Print() => $"{Number}";
}