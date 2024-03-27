namespace MyUniqueList;

/// <summary>
/// Class that causes an exception if the item to be added is already in the list.
/// </summary>
public class InvalidAddOperationException : InvalidOperationException
{
    public InvalidAddOperationException()
    {
    }

    public InvalidAddOperationException(string message)
        : base(message)
    {
    }
}