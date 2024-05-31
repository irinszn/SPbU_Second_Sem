namespace MySkipList;

using System.Collections;

/// <summary>
/// Class that implements Skip list structure.
/// </summary>
/// <typeparam name="T">Type of elements in skip list.</typeparam>
public class SkipList<T> : IList<T>
    where T : IComparable<T>
{
    private const int MaxLevel = 32;

    private readonly SkipListNode nil = new (default, default, default);

    private readonly Random random = new ();

    private SkipListNode head;

    private SkipListNode downHead;

    private int version;

    /// <summary>
    /// Initializing class elements.
    /// </summary>
    public SkipList()
    {
        head = new (default, nil, default);

        var currentNode = head;

        for (var i = 0; i < MaxLevel - 1; i++)
        {
            currentNode.Down = new SkipListNode(default, nil, default);
            currentNode = currentNode.Down;
        }

        downHead = currentNode;
    }

    /// <inheritdoc/>
    public int Count { get; private set; }

    /// <inheritdoc/>
    public bool IsReadOnly => false;

    /// <inheritdoc/>
    public T this[int index]
    {
        get
        {
            if (index < 0 || index >= Count)
            {
                throw new ArgumentOutOfRangeException("Index out of range.");
            }

            var currentNode = downHead;

            for (var i = 0; i <= index; ++i)
            {
                currentNode = currentNode.Next ?? throw new InvalidOperationException("Can't be null.");
            }

            return currentNode.Value!;
        }

        set => throw new NotSupportedException("Can't change value by index.");
    }

    /// <inheritdoc/>
    public void Add(T value)
    {
        var newElement = InsertValue(head, value);
        if (newElement is not null)
        {
            head.Next = new SkipListNode(value, nil, newElement);
        }

        ++version;
        ++Count;
    }

    /// <inheritdoc/>
    public void Clear()
    {
        head = new (default, nil, default);
        var currentNode = head;
        for (var i = 0; i < MaxLevel - 1; ++i)
        {
            currentNode.Down = new SkipListNode(default, nil, default);
        }

        downHead = currentNode;
        ++version;
        Count = 0;
    }

    /// <inheritdoc/>
    public bool Contains(T value)
    {
        var foundValue = FindValue(head, value);

        if (foundValue == downHead)
        {
            return false;
        }

        return value.CompareTo(foundValue.Value) == 0;
    }

    /// <inheritdoc/>
    public void CopyTo(T[] array, int arrayIndex)
    {
        if (arrayIndex >= array.Length || arrayIndex < 0)
        {
            throw new ArgumentOutOfRangeException("Index out of range.");
        }

        if (array.Length - arrayIndex < Count)
        {
            throw new ArgumentException("Skip list is larger than interval to copy.");
        }

        var currentNode = downHead.Next;

        while (currentNode != nil)
        {
            array[arrayIndex] = currentNode!.Value ?? throw new InvalidOperationException("Can't be null.");

            currentNode = currentNode.Next;
            ++arrayIndex;
        }
    }

    /// <inheritdoc/>
    public IEnumerator<T> GetEnumerator()
        => new Enumerator(this);

    /// <inheritdoc/>
    public int IndexOf(T value)
    {
        var index = 0;
        var currentNode = downHead.Next;

        while (currentNode != nil)
        {
            if (value.CompareTo(currentNode!.Value) == 0)
            {
                return index;
            }

            currentNode = currentNode.Next;

            ++index;
        }

        return -1;
    }

    /// <inheritdoc/>
    public void Insert(int index, T value)
        => throw new NotSupportedException("Can't insert value by index");

    /// <inheritdoc/>
    public bool Remove(T value)
    {
        var success = false;
        RemoveValue(head, value, ref success);

        ++version;
        if (success)
        {
            --Count;
        }

        return success;
    }

    /// <inheritdoc/>
    public void RemoveAt(int index)
        => Remove(this[index]);

    /// <inheritdoc/>
    IEnumerator IEnumerable.GetEnumerator()
        => GetEnumerator();

    private void RemoveValue(SkipListNode startNode, T value, ref bool success)
    {
        if (startNode.Next is null)
        {
            throw new InvalidOperationException("Can't be null.");
        }

        while (startNode.Next != nil && value.CompareTo(startNode.Next!.Value) > 0)
        {
            startNode = startNode.Next;
        }

        if (startNode.Down is not null)
        {
            RemoveValue(startNode.Down, value, ref success);
        }

        if (startNode.Next != nil && value.CompareTo(startNode.Next.Value) == 0)
        {
            startNode.Next = startNode.Next.Next;
            success = true;
        }
    }

    private SkipListNode? InsertValue(SkipListNode startNode, T value)
    {
        if (startNode.Next is null)
        {
            throw new InvalidOperationException("Can't be null.");
        }

        while (startNode.Next != nil && value.CompareTo(startNode.Next!.Value) > 0)
        {
            startNode = startNode.Next;
        }

        SkipListNode? downElement;
        if (startNode.Down is null)
        {
            downElement = null;
        }
        else
        {
            downElement = InsertValue(startNode.Down, value);
        }

        if (downElement is not null || startNode.Down is null)
        {
            startNode.Next = new SkipListNode(value, startNode.Next, downElement);

            if (FlipCoin())
            {
                return startNode.Next;
            }
        }

        return null;
    }

    private bool FlipCoin() => random.Next() % 2 == 0;

    private SkipListNode FindValue(SkipListNode startNode, T value)
    {
        if (startNode.Next is null)
        {
            throw new InvalidOperationException("Can't be null.");
        }

        while (startNode.Next != nil && value.CompareTo(startNode.Next!.Value) >= 0)
        {
            startNode = startNode.Next;
        }

        if (startNode.Down is null)
        {
            return startNode;
        }

        return FindValue(startNode.Down, value);
    }

    /// <summary>
    /// Class that implements enumerator.
    /// </summary>
    private class Enumerator : IEnumerator<T>
    {
        private readonly int version;

        private readonly SkipList<T> skipList;

        private SkipListNode? currentNode;

        public Enumerator(SkipList<T> skipList)
        {
            currentNode = skipList.downHead;
            this.skipList = skipList;
            version = this.skipList.version;
        }

        /// <inheritdoc/>
        public T Current
        {
            get
            {
                if (currentNode is null)
                {
                    throw new InvalidOperationException("It is not valid element.");
                }

                return currentNode.Value!;
            }
        }

        /// <inheritdoc/>
        object IEnumerator.Current => Current;

        /// <inheritdoc/>
        public void Dispose() => GC.SuppressFinalize(this);

        /// <inheritdoc/>
        public bool MoveNext()
        {
            if (version != skipList.version)
            {
                throw new InvalidOperationException("Can't modify skip list during iteration.");
            }

            if (currentNode!.Next == skipList.nil)
            {
                currentNode = skipList.downHead;
                return false;
            }

            currentNode = currentNode.Next;

            return true;
        }

        /// <inheritdoc/>
        public void Reset()
        {
            if (version != skipList.version)
            {
                throw new InvalidOperationException("Can't modify skip list during iteration.");
            }

            currentNode = skipList.downHead;
        }
    }

    /// <summary>
    /// Class that implements node of skip list.
    /// </summary>
    private class SkipListNode
    {
        public SkipListNode(T? value, SkipListNode? next, SkipListNode? down)
        {
            Value = value;
            Next = next;
            Down = down;
        }

        public SkipListNode? Next { get; set; }

        public SkipListNode? Down { get; set; }

        public T? Value { get; }
    }
}