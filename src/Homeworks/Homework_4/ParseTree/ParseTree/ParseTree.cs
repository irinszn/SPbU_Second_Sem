namespace ParseTree;

/// <summary>
/// Class that implements Parse Tree.
/// </summary>
public class PTree
{
    /// <summary>
    /// Root of tree.
    /// </summary>
    private INode? root;

    /// <summary>
    /// Method that builds Parse Tree by the entered line.
    /// </summary>
    /// <param name="inputString">Entered line.</param>
    public void BuildTree(string inputString)
    {
        inputString = inputString.Replace('(', ' ');
        inputString = inputString.Replace(')', ' ');

        var expression = inputString.Split(' ', StringSplitOptions.RemoveEmptyEntries);

        var index = 0;

        root = Build(expression, ref index);

        if (index != expression.Length)
        {
            throw new ArgumentException("Incorrect expression", nameof(expression));
        }
    }

    /// <summary>
    /// Method that prints all Parse tree into console.
    /// </summary>
    /// <returns>Values of nodes.</returns>
    public string GetTree()
    {
        if (root is null)
        {
            throw new ArgumentNullException("Tree is empty");
        }

        return root.Print();
    }

    /// <summary>
    /// Method that calculates value of the Parse tree.
    /// </summary>
    /// <returns>Calculated expression.</returns>
    public float Calculate()
    {
        if (root is null)
        {
            throw new ArgumentNullException("Tree is empty");
        }

        try
        {
            return root.Calculate();
        }
        catch (DivideByZeroException)
        {
            throw new ArgumentException("Expression contains division by zero");
        }
        catch (ArgumentException)
        {
            throw new ArgumentException("Expression contains unknown operation");
        }
    }

    /// <summary>
    /// Method that checks if symbol is operation.
    /// </summary>
    /// <param name="symbol">Element of expression.</param>
    /// <returns>True if it is operation, else false.</returns>
    private bool IsOperation(string symbol) => (symbol == "+") || (symbol == "-") || (symbol == "*") || (symbol == "/");

    /// <summary>
    /// Method that builds Parse tree.
    /// </summary>
    /// <param name="expression">Input expression.</param>
    /// <param name="index">The element counter.</param>
    /// <returns>Node.</returns>
    private INode? Build(string[] expression, ref int index)
    {
        if (index == expression.Length)
        {
            return null;
        }

        if (IsOperation(expression[index]))
        {
            var operationNode = new OperationNode();
            operationNode.Operation = expression[index].ToCharArray()[0];
            ++index;

            operationNode.LeftChild = Build(expression, ref index) ?? throw new ArgumentException();
            operationNode.RightChild = Build(expression, ref index) ?? throw new ArgumentException();

            return operationNode;
        }

        if (int.TryParse(expression[index], out int number))
        {
            ++index;
            var operandNode = new OperandNode();
            operandNode.Number = number;

            return operandNode;
        }

        throw new ArgumentException("Incorrect expression", nameof(expression));
    }
}