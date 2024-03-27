namespace MyUniqueList;

/// <summary>
/// Class that causes an exception if the item being modified is already in the list.
/// </summary>
public class InvalidChangeOperationException : InvalidOperationException
{
    public InvalidChangeOperationException()
    {
    }

    public InvalidChangeOperationException(string message)
        : base(message)
    {
    }
}