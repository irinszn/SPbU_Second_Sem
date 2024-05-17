namespace Final_Test.Test;

using Sort;

public class Tests
{
    [TestCase()]
    public void BubbleSort_WorksCorrectly_ForInt()
    {
        var expectedList = new List<int> { 7, 8, 9, 10 };
        var list = new List<int> { 10, 9, 8, 7 };

        IComparer<int> comparer = Comparer<int>.Default;
        var sortedList = BubbleSort<int>.Sort(list, comparer);

        Assert.That(expectedList, Is.EqualTo(sortedList));
    }
}