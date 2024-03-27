namespace UniqueList.Test;

using MyUniqueList;

public class Tests
{
    private MyList<int> emptyList;

    private MyList<int> list;

    private MyUniqueList<int> uList;

    [SetUp]
    public void Setup()
    {
        emptyList = new MyList<int>();
        list = new MyList<int>() {1, 2, 3, 4, 5};
        uList = new MyUniqueList<int>() {1, 2, 3, 4, 5};
    }

    private bool IsEqual(MyList<int> list, int[] expected)
    {
        if (expected.Length != list.Size)
        {
            return false;
        }

        for (var i = 0; i < list.Size; ++i)
        {
            if (list[i] != expected[i])
            {
                return false;
            }
        }

        return true;
    }

    [TestCase( 1, 2, 3, 4, 5)]
    public void CorrectAddAndCorrectSize(params int[] expected)
    {
        foreach (var element in expected)
        {
            emptyList.Add(element);
        }

        Assert.That((IsEqual(emptyList, expected)) && (emptyList.Size == expected.Length));
    }

    [TestCase(555, 1, 2, 100, 3, 4, 5, 777)]
    public void CorrectInsert_WithCorrectInput(params int[] expected)
    {
        list.Insert(2, 100);
        list.Insert(0,555);
        list.Insert(list.Size, 777);

        Assert.That(IsEqual(list, expected));
    }

    [TestCase(2, 4, 5)]
    public void CorrectRemove_WithCorrectInput(params int[] expected)
    {
        list.Remove(2);
        list.Remove(0);

        Assert.That(IsEqual(list, expected));
    }

    [TestCase(1, 2, 12345, 4, 0)]
    public void CorrectChangeValue(params int[] expected)
    {
        list.Change(2, 12345);
        list.Change(4, 0);

        Assert.That(IsEqual(list, expected));
    }

    [TestCase(1, 2, 3, 4, 5)]
    public void GetValueWorksCorrectly(params int[] array)
    {
        var expected = true;
        for (var i = 0; i < list.Size; ++i)
        {
            if (list.GetValue(i) != array[i])
            {
                expected = false;
            }
        }

        Assert.That(expected);
    }

    [TestCase(1, 2, 3, 4, 5)]
    public void IndexatorWorksCorrectly(params int[] array)
    {
        var expected = true;
        for (var i = 0; i < list.Size; ++i)
        {
            if (list[i] != array[i])
            {
                expected = false;
            }
        }

        Assert.That(expected);
    }

    [TestCase(true, 5)]
    [TestCase(false, 10)]
    public void CorrectContains(bool expected, int element)
    {
        var result = uList.Contains(element);

        Assert.That(result == expected);
    }

    [Test]
    public void IndexOutOfRange_WithInsert_ThrowException()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => list.Insert(10, 34));
    }

    [Test]
    public void IndexOutOfRange_WithRemove_ThrowException()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => list.Remove(-1));
        Assert.Throws<ArgumentOutOfRangeException>(() => list.Remove(10));
    }

    [Test]
    public void CannotRemoveFromEmptyList()
    {
        Assert.Throws<InvalidRemoveOperationException>(() => emptyList.Remove(0));
    }

    [Test]
    public void CannotChangeIncorrectIndex()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => list.Change(-1, 10));
    }

    [Test]
    public void InsertRepeatedElementThrowException()
    {
        Assert.Throws<InvalidInsertOperationException>(() => uList.Insert(0, 1));
    }

    [Test]
    public void AddRepeatedElementThrowException()
    {
        Assert.Throws<InvalidAddOperationException>(() => uList.Add(4));
    }

    [Test]
    public void ChangeRepeatedElementThrowException()
    {
        Assert.Throws<InvalidChangeOperationException>(() => uList.Change(1, 1));
    }
}