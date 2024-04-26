namespace Tests;
using MyQueue;

public class Tests
{
    PriorityQueue<int> queue;

    [SetUp]
    public void Setup()
    {
        queue = new PriorityQueue<int>();
    }

    [Test]
    public void Add_WorksCorrectly()
    {
        var expectedValue = new int[] {10, 15, 3};
        var expectedPriority = new int[] {4, 2, 7};

        queue.Enqueue(10, 4);
        queue.Enqueue(15, 2);
        queue.Enqueue(3, 7);

        for (int i = 0; i < expectedValue.Length; ++i)
        {
            Assert.That((queue[i].Item1 == expectedValue[i]) && (queue[i].Item2 == expectedPriority[i]));
        }
    }
}