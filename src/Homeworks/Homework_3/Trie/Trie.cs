namespace PrefixTree;

public class Trie
{
    private Node root;

    public int Size { get; private set; }

    public Trie()
    {
        root = new Node(-1);
        Size = 0;
    }

    public bool Add (List<byte>? list, int value)
    {
        if (list == null)
        {
            throw new NullReferenceException("Can't be null");
        }
     
        if (!list.Any())
        {
            return false;
        }
   
        if (Contains(list))
        {
            return false;
        } 

        var currentNode = root;

        foreach (var bytes in list)
        {
            ++currentNode.BytesCount;

            if(!currentNode.Children.ContainsKey(bytes))
            {
                currentNode.Children[bytes] = new Node(value);
            }

            currentNode = currentNode.Children[bytes];
        }

        ++currentNode.BytesCount;
        ++Size;
        currentNode.IsTerminal = true;

        return true;
    }

    public bool Contains (List<byte> list)
    {
        if (list == null)
        {
            throw new NullReferenceException("Can't be null");
        }

        var currentNode = root;

        foreach (var bytes in list)
        {
            if (! currentNode.Children.ContainsKey(bytes))
            {
                return false;
            }

            currentNode = currentNode.Children[bytes];
        }

        return currentNode.IsTerminal;
    }

    public bool Remove (List<byte> list)
    {
        if (list == null)
        {
            throw new NullReferenceException("Can't be null");
        }

        if (!list.Any())
        {
            return false;
        }

        if (!Contains(list))
        {
            return false;
        } 

        var currentNode = root;

        foreach(var bytes in list)
        {
            --currentNode.BytesCount;

            if (currentNode.Children[bytes].BytesCount == 1)
            {
                currentNode.Children.Remove(bytes);
                --Size;
                return true;
            }

            currentNode = currentNode.Children[bytes];
        }

        --currentNode.BytesCount;
        --Size;
        currentNode.IsTerminal = false;

        return true;
    }

    public int HowManyStartsWithPrefix (List<byte> prefix)
    {
        if (prefix == null)
        {
            throw new NullReferenceException("Can't be null");
        }

        var currentNode = root;

        foreach (var symbol in prefix)
        {
            if (! currentNode.Children.ContainsKey(symbol))
            {
                return 0;
            }

            currentNode = currentNode.Children[symbol];
        }

        return currentNode.BytesCount;
    }

    public int GetValue(List<byte> list)
    {
        if (list == null)
        {
            throw new ArgumentNullException(nameof(list), "Can't be null");
        }

        var currentNode = root;

        foreach (var bytes in list)
        {
            if (!currentNode.Children.ContainsKey(bytes))
            {
                return -1;
            }

            currentNode = currentNode.Children[bytes];
        }

        return currentNode.Value;
    }

    private class Node
    {
        public Dictionary<byte,Node> Children { get; }

        public bool IsTerminal { get; set; }

        public int BytesCount { get; set; }

        public int Value { get; }

        public Node(int value)
        {
            Children = new Dictionary<byte,Node>();
            IsTerminal = false;
            Value = value;
        }
    }
}