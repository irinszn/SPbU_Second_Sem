namespace MyUniqueList;

/// <summary>
/// Class that causes an exception when trying to delete an item with incorrect index.
/// </summary>
public class InvalidRemoveOperationException : InvalidOperationException
{
    public InvalidRemoveOperationException()
    {
    }

    public InvalidRemoveOperationException(string message)
        : base(message)
    {
    }
}