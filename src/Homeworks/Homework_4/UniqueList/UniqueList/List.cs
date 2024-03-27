namespace MyUniqueList;

using System.Collections;

using System.Collections.Generic;

/// <summary>
/// Class that implements list.
/// </summary>
/// <typeparam name="T">Type of the list values.</typeparam>
public class MyList<T> : IEnumerable<T>
{
    /// <summary>
    /// The first element of list.
    /// </summary>
    private protected Node? head;

    /// <summary>
    /// The number of items in the list.
    /// </summary>
    /// <value>Get number, set number.</value>
    public int Size { get; private set; }

    /// <summary>
    /// Indexer for list.
    /// </summary>
    /// <value>Get index of element and return it's value.</value>
    public T this[int index]
    {
        get { return GetValue(index); }
        set { Change(index, value); }
    }

    /// <summary>
    /// Method to add element to the end of the list.
    /// </summary>
    /// <param name="element">Element to add.</param>
    public virtual void Add(T element)
    {
        var newNode = new Node(element);

        if (head == null)
        {
            head = newNode;
        }
        else
        {
            var currentNode = head;

            while (currentNode.Next != null)
            {
                currentNode = currentNode.Next;
            }

            currentNode.Next = newNode;
        }

        ++Size;
    }

    /// <summary>
    /// Method to insert element to a certain place.
    /// </summary>
    /// <param name="index">Place to insert.</param>
    /// <param name="element">Element to insert.</param>
    public virtual void Insert(int index, T element)
    {
        if (index < 0 || index > Size)
        {
            throw new ArgumentOutOfRangeException("Index out of range", nameof(index));
        }

        if (index == 0)
        {
            var next = head;
            head = new Node(element);
            head.Next = next;
        }
        else
        {
            var newNode = new Node(element);

            var previousNode = GetNode(index - 1);

            newNode.Next = previousNode.Next;
            previousNode.Next = newNode;
        }

        ++Size;
    }

    /// <summary>
    /// Method to remove element from list.
    /// </summary>
    /// <param name="index">Index of the element to remove.</param>
    public void Remove(int index)
    {
        if (index < 0 || index > this.Size)
        {
            throw new ArgumentOutOfRangeException("Index out of range", nameof(index));
        }

        if (Size == 0)
        {
            throw new InvalidRemoveOperationException("Can't remove element from empty list");
        }

        if (index == 0)
        {
            head = head!.Next;
        }
        else
        {
            var previousNode = GetNode(index - 1);
            previousNode.Next = previousNode.Next!.Next;
        }

        --Size;
    }

    /// <summary>
    /// Method to Change value of element with some index.
    /// </summary>
    /// <param name="index">Index of the element to change.</param>
    /// <param name="newElement">New element.</param>
    public virtual void Change(int index, T newElement)
    {
        if (index < 0 || index > this.Size)
        {
            throw new ArgumentOutOfRangeException("Index out of range", nameof(index));
        }

        GetNode(index).Value = newElement;
    }

    /// <summary>
    /// Method to get value of element by it's index.
    /// </summary>
    /// <param name="index">Index element to get it's value.</param>
    /// <returns></returns>
    public T GetValue(int index)
    {
        return GetNode(index).Value;
    }

    /// <summary>
    /// Allows to enumerate nodes.
    /// </summary>
    /// <returns>The value of the enumerated node.</returns>
    IEnumerator<T> IEnumerable<T>.GetEnumerator()
    {
        Node? currentNode = head;
        while (currentNode != null)
        {
            yield return currentNode.Value;
            currentNode = currentNode.Next;
        }
    }

    /// <summary>
    /// Implementation of the IEnumerable interface.
    /// </summary>
    /// <returns>Enumerator object.</returns>
    IEnumerator IEnumerable.GetEnumerator()
    {
        return ((IEnumerable<T>)this).GetEnumerator();
    }

    /// <summary>
    /// Method to get node by it's index.
    /// </summary>
    /// <param name="index">Index of node.</param>
    /// <returns>Node.</returns>
    private Node GetNode(int index)
    {
        var currentNode = head;

        for (var i = 0; i < index; i++)
        {
            currentNode = currentNode!.Next;
        }

        return currentNode!;
    }

    /// <summary>
    /// Class for implementing list nodes.
    /// </summary>
    private protected class Node
    {
        public Node(T value)
        {
            this.Value = value;
        }

        public T Value { get; set; }

        public Node? Next { get; set; }
    }
}
