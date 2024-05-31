namespace ParseTree;

/// <summary>
/// Class that implement node with operation.
/// </summary>
public class OperationNode : INode
{
    /// <summary>
    /// Type of operation.
    /// </summary>
    public char Operation { get; set; }

    /// <summary>
    /// Left child of node.
    /// </summary>
    public INode? LeftChild { get; set; }

    /// <summary>
    /// Right child of node.
    /// </summary>
    public INode? RightChild { get; set; }

    /// <summary>
    /// Calculate the value of subtree.
    /// </summary>
    /// <returns>esult of calculate.</returns>
    public float Calculate()
    {
        var leftSubtree = LeftChild!.Calculate();
        var rightSubtree = RightChild!.Calculate();

        try
        {
            return CalculateExpression(Operation, leftSubtree, rightSubtree);
        }
        catch (ArgumentException)
        {
            throw new ArgumentException("Expression contains unknown operation");
        }
        catch (InvalidOperationException)
        {
            throw new DivideByZeroException("Expression contains division by zero");
        }
    }

    /// <summary>
    /// Print subtree into console.
    /// </summary>
    /// <returns>Value of node.</returns>
    public string Print() => $"{Operation} {LeftChild?.Print()} {RightChild?.Print()}";

    /// <summary>
    /// Calculating the value.
    /// </summary>
    /// <param name="operation">Type of operation.</param>
    /// <param name="leftSubtree">Left subtree.</param>
    /// <param name="rightSubtree">Right subtree.</param>
    /// <returns></returns>
    private float CalculateExpression(char operation, float leftSubtree, float rightSubtree)
    {
        return Operation switch
        {
            '+' => leftSubtree + rightSubtree,
            '-' => leftSubtree - rightSubtree,
            '*' => leftSubtree * rightSubtree,
            '/' => (rightSubtree == 0) ? throw new DivideByZeroException() : leftSubtree / rightSubtree,
            _ => throw new ArgumentException()
        };
    }
}