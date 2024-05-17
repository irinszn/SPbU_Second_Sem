namespace Final_Test.Test;

using Sort;

public class Tests
{
    [Test]
    public void BubbleSort_WorksCorrectly_ForInt()
    {
        var expectedList = new List<int> { 7, 8, 9, 10 };
        var list = new List<int> { 10, 9, 8, 7 };

        IComparer<int> comparer = Comparer<int>.Default;
        var sortedList = BubbleSort<int>.Sort(list, comparer);

        Assert.That(expectedList, Is.EqualTo(sortedList));
    }

    [Test]
    public void BubbleSort_WorksCorrectly_ForString()
    {
        var expectedList = new List<string> { "apple", "banana", "cherry" };
        var list = new List<string> { "banana", "cherry", "apple" };

        IComparer<string> comparer = Comparer<string>.Default;
        var sortedList = BubbleSort<string>.Sort(list, comparer);

        Assert.That(expectedList, Is.EqualTo(sortedList));
    }

    [Test]
    public void BubbleSort_WorksCorrectly_WithSortedList()
    {
        var expectedList = new List<int> { 1, 2, 3, 4, 5 };
        var list = new List<int> { 1, 2, 3, 4, 5 };

        IComparer<int> comparer = Comparer<int>.Default;
        var sortedList = BubbleSort<int>.Sort(list, comparer);

        Assert.That(expectedList, Is.EqualTo(sortedList));
    }
}