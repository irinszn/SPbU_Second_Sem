namespace StackCalculator;

public class StackArray: IStack
{
    private float[] stack;
    
    private int arraySize = 2;
    
    private int topIndex;
    
    public StackArray() 
    {
       this.stack = new float [this.arraySize];
    }
    
    public bool IsEmpty
    {
        get {return topIndex == 0; }
    }

    public bool IsOverflow
    {
        get {return topIndex == arraySize; }
    }

    public void Push(float element)
    {
        if (IsOverflow)
        {
            arraySize = arraySize*2;
            Array.Resize(ref stack, arraySize);
        }

        stack[topIndex] = element;
        topIndex++;
    }
    
    public float Pop()
    {
        if (IsEmpty)
        {
            throw new InvalidOperationException("Stack is empty");
        }

        topIndex--;
        float topElement = stack[topIndex];
    
        return topElement;
    }

}







