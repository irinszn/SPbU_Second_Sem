namespace StackCalculator;

/// <summary>
/// Class that implements array-based stack.
/// </summary>
public class StackArray : IStack
{
    private float[] stack;

    private int topIndex;

    public StackArray()
    {
       this.stack = new float[2];
    }

    /// <inheritdoc/>
    public bool IsEmpty
    {
        get { return topIndex == 0; }
    }

    /// <summary>
    /// Checks if stack is overflow.
    /// </summary>
    public bool IsOverflow
    {
        get { return topIndex == stack.Length; }
    }

    /// <inheritdoc/>
    public void Push(float element)
    {
        if (IsOverflow)
        {
            Array.Resize(ref stack, stack.Length * 2);
        }

        stack[topIndex] = element;
        topIndex++;
    }

    /// <inheritdoc/>
    public float Pop()
    {
        if (IsEmpty)
        {
            throw new InvalidOperationException("Stack is empty.");
        }

        topIndex--;

        var topElement = stack[topIndex];

        return topElement;
    }
}