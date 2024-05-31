namespace SkipList.Test;

using MySkipList;

public class Tests
{
    SkipList<int> skipListEmpty;

    [SetUp]
    public void Setup()
        => skipListEmpty = new SkipList<int>();

    [Test]
    public void IsReadOnly_ShouldReturnFalse()
    {
        Assert.That(!skipListEmpty.IsReadOnly);
    }

    [Test]
    public void ContainsAfterAdd_ShouldReturnTrue()
    {
        var value = 3;
        skipListEmpty.Add(value);

        Assert.That(skipListEmpty.Contains(3));
    }

    [Test]
    public void ContainsAfterRemove_ShouldReturnFalse()
    {
        var values = new[] { 1, 2, 3, 5 };
        foreach (var value in values)
        {
            skipListEmpty.Add(value);
        }

        skipListEmpty.Remove(3);
        Assert.That(!skipListEmpty.Contains(3));
    }

    [Test]
    public void ContainsNotExistingElement_ShouldReturnFalse()
    {
        Assert.That(!skipListEmpty.Contains(3));
    }

    [Test]
    public void CountAfterAdd_ShouldReturnCorrectResult()
    {
        var skipList = new SkipList<int> { 1, 2, 3, 5 };

        var expected = 4;

        Assert.That(skipList.Count, Is.EqualTo(expected));
    }

    [Test]
    public void CountAfterRemove_ShouldREturnCorrectResult()
    {
        var skipList = new SkipList<int> { 1, 2, 3, 5, -10, 100 };

        skipList.Remove(0);
        skipList.Remove(-100);
        skipList.Remove(2);
        skipList.Remove(100);

        var expected = 4;

        Assert.That(skipList.Count, Is.EqualTo(expected));
    }

    [Test]
    public void IndexerWithAddAndRemove_WithCorrectIndex_ShouldReturnExpectedResult()
    {
        Array.ForEach(new int[] { 1, 2, 3, 5, -10, 100 }, skipListEmpty.Add);

        skipListEmpty.Remove(0);
        skipListEmpty.Remove(100);

        var expected = new int[] { -10, 1, 2, 3, 5 };

        for (var i = 0; i < expected.Length; ++i)
        {
            Assert.That(skipListEmpty[i], Is.EqualTo(expected[i]));
        }
    }

    [Test]
    public void Indexer_WithIncorrectIndex_ThrowException()
    {
        int value;
        skipListEmpty.Add(1);

        Assert.Throws<ArgumentOutOfRangeException>(() => value = skipListEmpty[10]);
        Assert.Throws<ArgumentOutOfRangeException>(() => value = skipListEmpty[-10]);
    }

    [Test]
    public void SetValueByIndex_ThrowsException()
    {
        Assert.Throws<NotSupportedException>(() => skipListEmpty[0] = 1);
    }

    [Test]
    public void Clear_WorksCorrectly()
    {
        var skipList = new SkipList<int> { 1, 2, 3, 5, -10, 100 };

        skipList.Clear();

        Assert.That(skipList.Count == 0);
    }

    [Test]
    public void CopyTo_WithCorrectInput_WorksCorrectly()
    {
        var skipList = new SkipList<int> { 1, 2, 3, 5 };

        var array = new int[10];

        skipList.CopyTo(array, 2);

        var expectedArray = new int[] { 0, 0, 1, 2, 3, 5, 0, 0, 0, 0 };

        Assert.That(array, Is.EqualTo(expectedArray));
    }

    [Test]
    public void CopyTo_WithIndexOutOfRange_ThrowsException()
    {
        var array = new int[10];

        Assert.Throws<ArgumentOutOfRangeException>(() => skipListEmpty.CopyTo(array, 11));
        Assert.Throws<ArgumentOutOfRangeException>(() => skipListEmpty.CopyTo(array, -11));
    }

    [Test]
    public void CopyTo_WithCopyToSmallInterval_ThrowsException()
    {
        var skipList = new SkipList<int> { 1, 2, 10, 5 };

        var array = new int[10];

        Assert.Throws<ArgumentException>(() => skipList.CopyTo(array, 8));
    }

    [Test]
    public void Foreach_WorksCorrectly()
    {
        Array.ForEach(new int[] { 1, -10, 8, 5 }, skipListEmpty.Add);

        var expected = new int[] { -10, 1, 5, 8 };

        var actual = new List<int>();

        foreach (var element in skipListEmpty)
        {
            actual.Add(element);
        }

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void ModifySkipListDuringIteration_ThrowsException()
    {
        Array.ForEach(new int[] { 1, -10, 8, 5 }, skipListEmpty.Add);

        var iterator = skipListEmpty.GetEnumerator();

        skipListEmpty.Remove(8);

        Assert.Throws<InvalidOperationException>(() => iterator.MoveNext());
    }

    [Test]
    public void IndexOf_WorksCorrectly()
    {
        var skipList = new SkipList<int> { 1, 2, 5, 10 };

        Assert.That(skipList.IndexOf(10), Is.EqualTo(3));
        Assert.That(skipList.IndexOf(100), Is.EqualTo(-1));
    }

    [Test]
    public void InsertByIndex_ThrowsException()
    {
        Assert.Throws<NotSupportedException>(() => skipListEmpty.Insert(0, 1));
    }

    [Test]
    public void Remove_WorksCorrectly()
    {
        var skipList = new SkipList<int> { 1, 2, 5, 10, -10 };

        skipList.Remove(2);
        skipList.Remove(-10);

        var expected = new int[] { 1, 5, 10 };

        var actual = new List<int>();

        foreach (var element in skipList)
        {
            actual.Add(element);
        }

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void RemoveNotExistingElement_ShouldReturnFalse()
    {
        Assert.That(!skipListEmpty.Remove(10));
    }

    [Test]
    public void RemoveAt_WorksCorrectly()
    {
        var skipList = new SkipList<int> { 1, 2, 5, 10 };

        skipList.RemoveAt(2);

        var expected = new int[] { 1, 2, 10 };

        var actual = new List<int>();

        foreach (var element in skipList)
        {
            actual.Add(element);
        }

        Assert.That(actual, Is.EqualTo(expected));
    }
}