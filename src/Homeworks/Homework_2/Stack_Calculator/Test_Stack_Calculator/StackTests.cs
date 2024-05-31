#pragma warning disable NUnit2005

namespace StackCalculatorTest;

using StackCalculator;

public class StackTests
{
    private static IEnumerable<TestCaseData> Stack()
    {
        yield return new TestCaseData(new StackArray());
        yield return new TestCaseData(new StackList());
    }

    [TestCaseSource(nameof(Stack))]
    public void PopAndPush_WorksCorrectly(IStack stack)
    {
        stack.Push(1);
        stack.Push(2);
        stack.Push(3);

        var actual = new List<float>();

        for (int i = 0; i < 3; ++i)
        {
            actual.Add(stack.Pop());
        }

        var expected = new int[] { 3, 2, 1 };

        Assert.AreEqual(expected, actual);
    }

    [TestCaseSource(nameof(Stack))]
    public void Pop_FromEmptyStack_ThrowsException(IStack stack)
        => Assert.Throws<InvalidOperationException>(() => stack.Pop());

    [TestCaseSource(nameof(Stack))]
    public void IsEmpty_WorksCorrectly(IStack stack)
        => Assert.That(stack.IsEmpty);

    [TestCaseSource(nameof(Stack))]
    public void IsEmpty_AfterPush_ReturnFalse(IStack stack)
    {
        stack.Push(10);
        Assert.That(!stack.IsEmpty);
    }
}