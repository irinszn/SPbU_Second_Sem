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
        var expected = new int[] {10, 4, 15, 2, 3, 7};

        queue.Enqueue(10, 4);
        queue.Enqueue(15, 2);
        queue.Enqueue(3, 7);

        Console.WriteLine(queue[1]);
        for (int i = 0; i < expected.Length; i += 2)
        {
            Assert.That((queue[i].Item1 == expected[i]) && (queue[i].Item2 == expected[i + 1]));
        }
    }
}