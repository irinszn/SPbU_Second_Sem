namespace StackCalculator;

/// <summary>
/// Class that implements stack based linked list.
/// </summary>
public class StackList : IStack
{
    private LinkedList<float> stack;

    public StackList()
    {
        stack = new LinkedList<float>();
    }

    /// <inheritdoc/>
    public bool IsEmpty
    {
        get { return stack.Count == 0; }
    }

    /// <inheritdoc/>
    public void Push(float element)
    {
        stack.AddLast(element);
    }

    /// <inheritdoc/>
    public float Pop()
    {
        if (IsEmpty)
        {
            throw new InvalidOperationException("Can't be empty.");
        }

        var lastElement = stack.Last();
        stack.RemoveLast();

        return lastElement;
    }
}