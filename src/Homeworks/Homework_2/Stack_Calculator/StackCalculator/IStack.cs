namespace StackCalculator;

/// <summary>
/// Implementation Stack structure.
/// </summary>
public interface IStack
{
    /// <summary>
    /// Method that puts element to the stack.
    /// </summary>
    /// <param name="element">Element to put.</param>
    public void Push(float element);

    /// <summary>
    /// Method that takes element from the stack.
    /// </summary>
    /// <returns>Element from stack.</returns>
    public float Pop();

    /// <summary>
    /// Check if stack is empty.
    /// </summary>
    public bool IsEmpty { get; }

}