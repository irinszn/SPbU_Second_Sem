namespace Functions.Test;

using MapFilterFold;

public class Test
{
    [Test]
    public void Map_WithCorrectIntInput_ShouldReturnExpectedResult()
    {
        var list = new List<int> { 1, 2, 3, 4, 5 };

        var expectedList = new List<int> { 2, 4, 6, 8, 10 };

        var actualList = Functions.Map(list, x => x * 2);

        Assert.That(actualList, Is.EqualTo(expectedList));
    }

    [Test]
    public void Map_WithCorrectStringInput_ShouldReturnExpectedResult()
    {
        var list = new List<string> { "a", "b", "c" };

        var expectedList = new List<string> { "a2", "b2", "c2" };

        var actualList = Functions.Map(list, x => x + "2");

        Assert.That(actualList, Is.EqualTo(expectedList));
    }

    [Test]
    public void Map_WithEmptyList_ShouldReturnExpectedResult()
    {
        var list = new List<string>();

        var expectedList = new List<string>();

        var actualList = Functions.Map(list, x => x + x);

        Assert.That(actualList, Is.EqualTo(expectedList));
    }

    [Test]
    public void Filter_WithCorrectInput_ShouldReturnExpectedResult()
    {
        var list = new List<int> { 1, 2, 3, 4, 5 };

        var expectedList = new List<int> { 2, 4 };

        var actualList = Functions.Filter(list, x => (x % 2) == 0);

        Assert.That(actualList, Is.EqualTo(expectedList));
    }

    [Test]
    public void Filter_WithEmptyList_ShouldReturnExpectedResult()
    {
        var list = new List<int>();

        var expectedList = new List<int>();

        var actualList = Functions.Filter(list, x => x < 5);

        Assert.That(actualList, Is.EqualTo(expectedList));
    }

    [Test]
    public void Fold_WithCorrectInput_ShouldReturnExpectedResult()
    {
        var list = new List<int> { 1, 2, 3, 4, 5 };

        var initValue = 2;

        var expected = 240;

        var actual = Functions.Fold(list, initValue, (initValue, x) => initValue * x);

        Assert.That(actual == expected);
    }

    [Test]
    public void Fold_WithEmptyList_ShouldReturnexpectedResult()
    {
        var list = new List<int>();

        var initValue = 1;

        var expected = 1;

        var actual = Functions.Fold(list, initValue, (initValue, x) => x + initValue);

        Assert.That(actual == expected);
    }
}