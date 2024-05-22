namespace MyQueue;

/// <summary>
/// Class that implements Priority Queue based on a tuple.
/// </summary>
/// <typeparam name="T">Type of elements in queue.</typeparam>
public class PriorityQueue<T>
{
    /// <summary>
    /// The tuple on which queue is based.
    /// </summary>
    private List<(T, int)> queue = new List<(T, int)> ();

    /// <summary>
    /// Indexator for queue.
    /// </summary>
    public (T, int) this[int index]
    {
        get 
        {
           return queue[index];
        }
        set
        {
            queue[index] = value; ;
        }
    }

    /// <summary>
    /// Method that Add element in queue.
    /// </summary>
    /// <param name="value">Value of element.</param>
    /// <param name="priority">Priority of element.</param>
    public void Enqueue(T value, int priority)
    {
        queue.Add((value, priority));
    }

    /// <summary>
    /// Method that returns value with the highest priority and removes it from the queue, throw exception if queue is empty.
    /// </summary>
    /// <returns>Value with the highest priority.</returns>
    public T Dequeue()
    {
        if (queue.Count == 0)
        {
            throw new InvalidOperationException("Queue is empty");
        }

        int hightPriorityIndex = 0;

        for (var i = 1; i < queue.Count; ++i)
        {
            if (queue[i].Item2 > queue[hightPriorityIndex].Item2)
            {
                hightPriorityIndex = i;
            }
        }

        var hightPriorityElement = queue[hightPriorityIndex].Item1;

        queue.RemoveAt(hightPriorityIndex);

        return hightPriorityElement;
    }

    /// <summary>
    /// Checks if the queue is empty.
    /// </summary>
    public bool IsEmpty
    {
        get { return queue.Count == 0; }
    }
}
