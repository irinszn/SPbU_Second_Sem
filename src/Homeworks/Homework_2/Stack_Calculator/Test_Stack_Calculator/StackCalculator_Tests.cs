using StackCalculator;

namespace StackCalculatorTest;

public class CalculatorTests
{
    private static IEnumerable<TestCaseData> StackCalculator()
    {
        yield return new TestCaseData(new PolishCalculator(new StackArray()));
        yield return new TestCaseData(new PolishCalculator(new StackList()));
    }

    private readonly float Const = 0.01e-4F;

    [TestCaseSource(nameof(StackCalculator))]
    public void CorrectWorkStackCalculator_WithCorrectInput(PolishCalculator calculator)
    {
        var expression = "7 2 3 * - 12 / 2 +";
        double expected = 2.083333;
        
        var actual = calculator.CalculateExpression(expression);

        Assert.That(Math.Abs(actual - expected) < Const); 
    }

    [TestCaseSource(nameof(StackCalculator))]
    public void StackCalculatorThrowExeption_WithDivisionByNull(PolishCalculator calculator)
    {
        var expression = "7 0 /";

        Assert.Throws<DivideByZeroException> (() => calculator.CalculateExpression(expression)); 
    }

    [TestCaseSource(nameof(StackCalculator))]
    public void StackCalculatorThrowExeption_WithNull(PolishCalculator calculator)
    {
        Assert.Throws<NullReferenceException> (() => calculator.CalculateExpression(null));

    }

    [TestCaseSource(nameof(StackCalculator))]
    public void StackCalculatorThrowExeption_WithEmptyString(PolishCalculator calculator)
    {
        Assert.Throws<NullReferenceException> (() => calculator.CalculateExpression(string.Empty));

    }

    [TestCaseSource(nameof(StackCalculator))]
    public void StackCalculatorThrowExeption_WithIncorrectInput(PolishCalculator calculator)
    {
        var expression = "1 + 1";

        Assert.Throws<InvalidOperationException> (() => calculator.CalculateExpression(expression)); 
    }

    [TestCaseSource(nameof(StackCalculator))]
    public void StackCalculatorThrowExeption_IncorrectInputWithExtraSpaces(PolishCalculator calculator)
    {
        var expression = "2 2 + ";

        Assert.Throws<InvalidOperationException> (() => calculator.CalculateExpression(expression)); 
    }

    [TestCaseSource(nameof(StackCalculator))]
    public void StackCalculatorThrowExeption_IncorrectInputWithExtraNumbers(PolishCalculator calculator)
    {
        var expression = "2 3 4 +";

        Assert.Throws<InvalidOperationException> (() => calculator.CalculateExpression(expression)); 
    }

    [TestCaseSource(nameof(StackCalculator))]
    public void StackCalculatorThrowExeption_IncorrectInputWithUnknownOperations(PolishCalculator calculator)
    {
        var expression = "2 7 $";

        Assert.Throws<InvalidOperationException> (() => calculator.CalculateExpression(expression)); 
    }

    [TestCaseSource(nameof(StackCalculator))]
    public void StackCalculatorThrowExeption_IncorrectInputBeginWithOperation(PolishCalculator calculator)
    {
        var expression = "+ 3 4";

        Assert.Throws<InvalidOperationException> (() => calculator.CalculateExpression(expression)); 
    }

    [TestCaseSource(nameof(StackCalculator))]
    public void StackCalculatorThrowExeption_IncorrectInputWithUnknownSymbols(PolishCalculator calculator)
    {
        var expression = "b c +";

        Assert.Throws<InvalidOperationException> (() => calculator.CalculateExpression(expression)); 
    }
    
}