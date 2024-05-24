namespace StackCalculator;

/// <summary>
/// Class that implements array-based stack.
/// </summary>
public class StackArray: IStack
{
    private float[] stack;
    
    private int arraySize = 2;
    
    private int topIndex;
    
    public StackArray() 
    {
       this.stack = new float[this.arraySize];
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
        get { return topIndex == arraySize; }
    }

    /// <inheritdoc/>
    public void Push(float element)
    {
        if (IsOverflow)
        {
            arraySize = arraySize * 2;
            Array.Resize(ref stack, arraySize);
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







