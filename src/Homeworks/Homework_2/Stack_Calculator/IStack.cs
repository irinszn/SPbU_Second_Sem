namespace StackCalculator;
public interface IStack
{
    public void Push(float element);

    public float Pop();

    public bool IsEmpty {get; }

}