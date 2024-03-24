namespace PrefixTree;

/// <summary>
/// Class implements Trie structure.
/// </summary>
public class Trie
{
    /// <summary>
    /// The beginning if the tree.
    /// </summary>
    private Node root;

    /// <summary>
    /// Inicializing a new object of the Trie class.
    /// </summary>
    public Trie()
    {
        this.root = new Node();
        this.Size = 0;
    }

    /// <summary>
    /// Gets the number of elements in the tree, set size .
    /// </summary>
    public int Size { get; private set; }

    /// <summary>
    /// Adds an element to the tree.
    /// </summary>
    /// <param name="element">Element to add.</param>
    /// <returns>True if element wasn't in the tree and it was added, else false.</returns>
    /// <exeption cref="NullReferenceException">Element can't be null.</exception>
    public bool Add(string element)
    {
        if (element == null)
        {
            throw new NullReferenceException("Can't be null");
        }

        if (element == string.Empty)
        {
            if (this.root.IsTerminal)
            {
                return false;
            }

            ++this.Size;
            this.root.IsTerminal = true;

            return true;
        }

        if (this.Contains(element))
        {
            return false;
        }

        var currentNode = this.root;

        foreach (var symbol in element)
        {
            ++currentNode.WordsCount;

            if (!currentNode.Children.ContainsKey(symbol))
            {
                currentNode.Children[symbol] = new Node();
            }

            currentNode = currentNode.Children[symbol];
        }

        ++currentNode.WordsCount;
        ++this.Size;
        currentNode.IsTerminal = true;

        return true;
    }

    /// <summary>
    /// Checks if element is contained in the tree.
    /// </summary>
    /// <param name="element">Element to check.</param>
    /// <returns>True if element contains, else false.</returns>
    /// <exeption cref="NullReferenceException">Element can't be null.</exception>
    public bool Contains(string element)
    {
        if (element == null)
        {
            throw new NullReferenceException("Can't be null");
        }

        var currentNode = this.root;

        foreach (var symbol in element)
        {
            if (!currentNode.Children.ContainsKey(symbol))
            {
                return false;
            }

            currentNode = currentNode.Children[symbol];
        }

        return currentNode.IsTerminal;
    }

    /// <summary>
    /// Removes element from the tree.
    /// </summary>
    /// <param name="element">Element to remove.</param>
    /// <returns>True if element was in the tree and it was removed, else false.</returns>
    /// <exeption cref="NullReferenceException">Element can't be null.</exception>
    public bool Remove(string element)
    {
        if (element == null)
        {
            throw new NullReferenceException("Can't be null");
        }

        if (element == string.Empty)
        {
            if (!this.root.IsTerminal)
            {
                return false;
            }

            --this.Size;

            return !(this.root.IsTerminal = false);
        }

        if (!this.Contains(element))
        {
            return false;
        }

        var currentNode = this.root;

        foreach (var symbol in element)
        {
            --currentNode.WordsCount;

            if (currentNode.Children[symbol].WordsCount == 1)
            {
                currentNode.Children.Remove(symbol);
                --this.Size;
                return true;
            }

            currentNode = currentNode.Children[symbol];
        }

        --currentNode.WordsCount;
        --this.Size;
        currentNode.IsTerminal = false;

        return true;
    }

    /// <summary>
    /// Method that finds how many words starts with a given prefix.
    /// </summary>
    /// <param name="prefix">Prefix for verification.</param>
    /// <returns>How many words starts with this prefix.</returns>
    /// <exeption cref="NullReferenceException">Prefix can't be null.</exception>
    public int HowManyStartsWithPrefix(string prefix)
    {
        if (prefix == null)
        {
            throw new NullReferenceException("Can't be null");
        }

        var currentNode = this.root;

        foreach (var symbol in prefix)
        {
            if (!currentNode.Children.ContainsKey(symbol))
            {
                return 0;
            }

            currentNode = currentNode.Children[symbol];
        }

        return currentNode.WordsCount;
    }

    /// <summary>
    /// Class that implements node of trie.
    /// </summary>
    private class Node
    {
        /// <summary>
        /// Initializing a trie node.
        /// </summary>
        public Node()
        {
            this.Children = new Dictionary<char, Node>();
            this.IsTerminal = false;
        }

        /// <summary>
        /// Structure for storing children of each node.
        /// </summary>
        public Dictionary<char, Node> Children { get; }

        /// <summary>
        /// Check if node is terminal.
        /// </summary>
        public bool IsTerminal { get; set; }

        /// <summary>
        /// How many words starts from this node, including its.
        /// </summary>
        public int WordsCount { get; set; }
    }
}