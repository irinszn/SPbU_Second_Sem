namespace PrefixTree;

public class Node
{
    public Dictionary<char,Node> Children {get; }

    public bool IsTerminal {get; set; }

    public int WordsCount {get; set; }

    public Node()
    {
        Children = new Dictionary<char,Node>();
        IsTerminal = false;
    }

}

public class Trie
{

    private Node root;

    public int Size {get; set;}

    public Trie()
    {
        this.root = new Node();
        this.Size = 0;
    }

    public bool Add (string? element)
    {
        if (element == null)
        {
            throw new NullReferenceException("Can't be null");
        }
     
        if (element == string.Empty)
        {
            if (root.IsTerminal)
            {
                return false;
            }

            ++Size;
            root.IsTerminal = true;

            return true;

        }
   
        if (Contains(element))
        {
            return false;
        } 

        var currentNode = root;

        foreach (var symbol in element)
        {
            ++currentNode.WordsCount;

            if(!currentNode.Children.ContainsKey(symbol))
            {
                currentNode.Children[symbol] = new Node();
            }

            currentNode = currentNode.Children[symbol];

        }

        ++currentNode.WordsCount;
        ++Size;
        currentNode.IsTerminal = true;

        return true;

    }

    public bool Contains (string? element)
    {
        if (element == null)
        {
            throw new NullReferenceException("Can't be null");
        }

        var currentNode = root;

        foreach (var symbol in element)
        {
            if (! currentNode.Children.ContainsKey(symbol))
            {
                return false;
            }

            currentNode = currentNode.Children[symbol];
            
        }

        return currentNode.IsTerminal;

    }

    public bool Remove (string? element)
    {
        if (element == null)
        {
            throw new NullReferenceException("Can't be null");
        }

         if (element == string.Empty)
        {
            if (!root.IsTerminal)
            {
                return false;
            }
            
            --Size;

            return !(root.IsTerminal = false);

        }
        
        if (!Contains(element))
        {
            return false;
        } 

        var currentNode = root;

        foreach( var symbol in element)
        {
            --currentNode.WordsCount;

            if (currentNode.Children[symbol].WordsCount == 1)
            {
                currentNode.Children.Remove(symbol);
                --Size;
                return true;
            }

            currentNode = currentNode.Children[symbol];
        }

        --currentNode.WordsCount;
        --Size;
        currentNode.IsTerminal = false;

        return true;
    }

    public int HowManyStartsWithPrefix (string prefix)
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

        return currentNode.WordsCount;
    }

}