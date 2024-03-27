namespace MyUniqueList;

/// <summary>
/// Class that causes an exception if the item to be added is already in the list.
/// </summary>
public class InvalidInsertOperationException : InvalidOperationException
{
    public InvalidInsertOperationException()
    {
    }

    public InvalidInsertOperationException(string message)
        : base(message)
    {
    }
}