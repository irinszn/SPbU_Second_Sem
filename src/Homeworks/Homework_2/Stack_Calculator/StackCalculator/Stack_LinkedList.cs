namespace StackCalculator;

public class StackList: IStack
{
    private LinkedList<float> stack;

    public StackList()
    {
        stack = new LinkedList<float>();
    }

    public bool IsEmpty
    {
        get{return stack.Count == 0; }
    }

    public void Push(float element)
    {
        stack.AddLast(element);
    }

    public float Pop()
    {
        if (IsEmpty)
        {
            throw new InvalidOperationException("Can't be empty");
        }

        float lastElement = stack.Last();
        stack.RemoveLast();

        return lastElement;

    }

}