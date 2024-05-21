namespace SparseVector.Test;

using SparseVector;

public class Tests
{
    Vector vector;

    [SetUp]
    public void Setup()
    {
        vector = new Vector();
    }

    [Test]
    public void AddValue_GetValue_WorksCorrectly()
    {
        vector.AddValue(0,1);
        vector.AddValue(1,2);
        vector.AddValue(2,3);

        for (var i = 0; i < 3; ++i)
        {
            Assert.That(i + 1, Is.EqualTo(vector.GetValue(i)));
        }
    }

    [Test]
    public void Indexator_WorksCorrectly()
    {
        vector[0] = 1;
        vector[1] = 2;
        vector[2] = 3;

        for (var i = 0; i < 3; ++i)
        {
            Assert.That(i + 1, Is.EqualTo(vector[i]));
        }
    }

    [TestCase(true, 0, 0, 0)]
    [TestCase(false, 0, 1, 0)]
    public void IfIsNull_WorksCorrectly(bool expected, params float[] values)
    {
        for (var i = 0; i < values.Length; ++i)
        {
            vector[i] = values[i];
        }

        var actual = vector.IfIsNull();

        Assert.That(actual, Is.EqualTo(expected));
    }

    [TestCase(2, 4, 6)]
    public void Add_WorksCorrectly(params float[] expected)
    {
        var newVector = new Dictionary<int, float>();

        var values = new int[] { 1, 2, 3 };

        for (var i = 0; i < values.Length; ++i)
        {
            vector[i] = values[i];
            newVector.Add(i, values[i]);
        }

        var result = vector.Add(newVector);

        var j = 0;

        foreach (var element in result)
        {
            Assert.That(result[element.Key], Is.EqualTo(expected[j]));
            j++;
        }
    }

    [TestCase(0, 0, 0)]
    public void Subtract_WorksCorrectly(params float[] expected)
    {
        var newVector = new Dictionary<int, float>();

        var values = new int[] { 1, 2, 3 };

        for (var i = 0; i < values.Length; ++i)
        {
            vector[i] = values[i];
            newVector.Add(i, values[i]);
        }

        var result = vector.Subtract(newVector);

        var j = 0;

        foreach (var element in result)
        {
            Assert.That(result[element.Key], Is.EqualTo(expected[j]));
            j++;
        }
    }

    [TestCase(14, 1, 2, 3)]
    public void ScalarMultiplication_WorksCorrectly(float expected, params float[] values)
    {
        var newVector = new Vector();

        for (var i = 0; i < values.Length; ++i)
        {
            vector[i] = values[i];
            newVector[i] = values[i];
        }

        var result = vector.ScalarMultiplication(newVector);

        Assert.That(result, Is.EqualTo(expected));
    }
}