namespace MyUniqueList;

/// <summary>
/// Class that implements unique list, no repetitive elements.
/// </summary>
/// <typeparam name="T"></typeparam>
public class MyUniqueList<T> : MyList<T>
{
    /// <summary>
    /// Method that checks if an element is in the list.
    /// </summary>
    /// <param name="element"></param>
    /// <returns>False if element contains, else true.</returns>
    public bool Contains(T element)
    {
        if (head == null)
        {
            return false;
        }

        Node currentNode = head!;

        for (var i = 0; i < Size - 1; ++i)
        {
            if (currentNode.Value!.Equals(element))
            {
                return true;
            }

            currentNode = currentNode.Next!;
        }

        return currentNode.Value!.Equals(element);
    }

    /// <summary>
    /// Method to insert element to a certain place and throw exception if element is already contained in the list.
    /// </summary>
    /// <param name="index">Place to insert.</param>
    /// <param name="element">Element to add.</param>
    public override void Insert(int index, T element)
    {
        if (Contains(element))
        {
            throw new InvalidInsertOperationException();
        }

        base.Insert(index, element);
    }

    /// <summary>
    /// Method to add element to the end of the list and throw exception if element is already contained in the list.
    /// </summary>
    /// <param name="element">Element to add.</param>
    public override void Add(T element)
    {
        if (Contains(element))
        {
            throw new InvalidAddOperationException();
        }

        base.Add(element);
    }

    /// <summary>
    /// Method to change value of element with some index and throw exception if element is already contained in the list.
    /// </summary>
    /// <param name="index">Index of the element to change.</param>
    /// <param name="element">New element.</param>
    public override void Change(int index, T element)
    {
        if (Contains(element))
        {
            throw new InvalidChangeOperationException();
        }

        base.Change(index, element);
    }
}