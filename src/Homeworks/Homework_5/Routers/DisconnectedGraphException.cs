namespace Routers;

/// <summary>
/// Class that implements DisconnectedGraphException.
/// </summary>
public class DisconnectedGraphException : Exception
{
    public DisconnectedGraphException()
    {
    }

    public DisconnectedGraphException(string message)
        : base(message)
    {
    }
}