using PrefixTree;

namespace TrieTest;

public class Tests
{
    private Trie trie;

    [SetUp]
    public void Setup()
    {
        trie = new Trie();
    }

    [TestCase(true," ", "", "apple", "banana", "watermelon")]
    [TestCase(false, "", "", "", "")]
    [TestCase(false, "apple","banana", "banana")]
    [TestCase(true, "1234","12345", "123456")]
    [TestCase(true, "яблоко","банан", "сочный арбуз", "барабан")]
    [TestCase(false, "a","p", "p", "l", "e")]
    public void CorrectAdd(bool expected, params string[] words)
    {
        var actual = true;

        foreach (var element in words)
        {
            actual = trie.Add(element) && actual;
        }

        Assert.That(actual == expected);
    }

    [TestCase(5," ","", "apple", "banana", "watermelon")]
    [TestCase(1, "", "", "", "")]
    [TestCase(3, "1234","12345", "123456")]
    [TestCase(2, "apple","banana", "banana")]
    public void CorrectAddWithCorrectSize(int expectedSize, params string[] words)
    {

        foreach (var element in words)
        {
            trie.Add(element);
        }

        int actualSize = trie.Size;

        Assert.That(actualSize == expectedSize);
    }

    [TestCase(false," ", "", "apple", "banana", "watermelon")]
    [TestCase(true, "", "", "", "")]
    [TestCase(false, "banana","apple", "banan")]
    [TestCase(false, "1234","12345", "123456")]
    [TestCase(true, "сочный арбуз","банан", "сочный арбуз", "барабан")]
    [TestCase(false, "","apple", "banan")]
    public void CorrectAddAndThenCorrectContains(bool expected, string word, params string[] words)
    {

        foreach (var element in words)
        {
            trie.Add(element);
        }

        var actual = trie.Contains(word);

        Assert.That(actual == expected);
    }

    [TestCase(false," ", "", "apple", "banana", "watermelon")]
    [TestCase(true, "", "", "", "")]
    [TestCase(false, "banana","apple", "banan")]
    [TestCase(false, "1234","12345", "123456")]
    [TestCase(true, "сочный арбуз","банан", "сочный арбуз", "барабан")]
    public void CorrectRemove(bool expected, string wordToRemove, params string[] words)
    {

        foreach (var element in words)
        {
            trie.Add(element);
        }

        var actual = trie.Remove(wordToRemove);

        Assert.That(actual == expected);
    }

    [TestCase(false,"apple", "яблоко", "apple", "banana", "watermelon")]
    [TestCase(false, "", "", "", "")]
    public void CorrectRemoveAndThenCorrectContains(bool expected, string wordToRemove, params string[] words)
    {

        foreach (var element in words)
        {
            trie.Add(element);
        }

        trie.Remove(wordToRemove);
        var actual = trie.Contains(wordToRemove);

        Assert.That(actual == expected);
    }

    [TestCase(3,"banana","m", "apple", "banana", "watermelon")]
    [TestCase(0, "", "", "", "")]
    [TestCase(2, "1234","12345", "123456")]
    public void CorrectRemoveAndCorrectSize(int expectedSize, string wordToDelete, params string[] words)
    {

        foreach (var element in words)
        {
            trie.Add(element);
        }

        trie.Remove(wordToDelete);
        int actualSize = trie.Size;

        Assert.That(actualSize == expectedSize);
    }

    [TestCase(0,"ananas","m", "apple", "banana", "watermelon")]
    [TestCase(4,"ban","ban", "bana", "banana", "bananas")]
    [TestCase(4,"","m", "apple", "banana", "watermelon")]
    public void CorrectHowManyStartsWithPrefix(int expectedCount, string prefix, params string[] words)
    {
        foreach (var element in words)
        {
            trie.Add(element);
        }

        int actualCount = trie.HowManyStartsWithPrefix(prefix);

        Assert.That(actualCount == expectedCount);
    }

    [TestCase(1,"ananas","app", "apple", "banana", "watermelon")]
    [TestCase(3,"ban","ban", "bana", "banana", "bananas")]
    public void CorrectHowManyStartsWithPrefixWithRemove(int expectedCount, string wordToDelete, string prefix, params string[] words)
    {
        foreach (var element in words)
        {
            trie.Add(element);
        }

        trie.Remove(wordToDelete);
        int actualCount = trie.HowManyStartsWithPrefix(prefix);
        
        Assert.That(actualCount == expectedCount);
    }
}