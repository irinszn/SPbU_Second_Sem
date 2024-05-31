namespace StackCalculator;

/// <summary>
/// Class that implements stack calculator.
/// </summary>
public class PolishCalculator
{
    private readonly IStack stack;

    /// <summary>
    /// Stack initialization.
    /// </summary>
    public PolishCalculator(IStack? stack)
    {
        this.stack = stack ?? throw new NullReferenceException("Can't be null");
    }

    /// <summary>
    /// Checks if element is operation.
    /// </summary>
    /// <param name="element">operation.</param>
    /// <returns>True if element is operation, else false.</returns>
    public bool IsSign(string element) => element == "+" || element == "-" || element == "*" || element == "/";

    /// <summary>
    /// Checks if input string is in correct format.
    /// </summary>
    /// <param name="inputString">Input string.</param>
    /// <returns>Array of operations and operators.</returns>
    public string[] CheckString(string? inputString)
    {
        if (inputString == null || inputString == string.Empty)
        {
            throw new NullReferenceException("String can't be empty or null");
        }

        var stringArray = inputString.Split(' ');

        if (!int.TryParse(stringArray[0], out var _))
        {
            throw new InvalidOperationException("Incorrect input");
        }

        int digitCount = 0;
        int operationCount = 0;

        foreach (var element in stringArray)
        {
            var isDigit = int.TryParse(element, out var _);

            if (isDigit)
            {
                digitCount++;
            }
            else if (IsSign(element))
            {
                operationCount++;
            }
            else
            {
                throw new InvalidOperationException("Incorrect input");
            }
        }

        if (digitCount - operationCount != 1)
        {
            throw new InvalidOperationException("Incorrect input");
        }

        return stringArray;
    }

    /// <summary>
    /// Method that calculate input expression.
    /// </summary>
    /// <param name="inputString">Input expression.</param>
    /// <returns>Result of calculations.</returns>
    public float CalculateExpression(string? inputString)
    {
        var stringArray = CheckString(inputString);

        foreach (var element in stringArray)
        {
            var isDigit = int.TryParse(element, out var number);

            if (isDigit)
            {
                stack.Push(number);
            }
            else if (IsSign(element))
            {
                float result = TransformValue(stack.Pop(), stack.Pop(), char.Parse(element));
                stack.Push(result);
            }
        }

        return stack.Pop();
    }

    /// <summary>
    /// Method that evaluates expression from two values.
    /// </summary>
    /// <param name="firstNumber">First operand.</param>
    /// <param name="secondNumber">Second operand.</param>
    /// <param name="operation">Operation.</param>
    /// <returns></returns>
    public float TransformValue(float firstNumber, float secondNumber, char operation)
    {
        const float NullConst = 0.01e-4F;

        switch (operation)
        {
            case '+':
                return firstNumber + secondNumber;

            case '-':
                return secondNumber - firstNumber;

            case '*':
                return firstNumber * secondNumber;

            case '/':
                {
                    if (Math.Abs(firstNumber) < NullConst)
                    {
                        throw new DivideByZeroException("Division by zero");
                    }
                    else
                    {
                        return secondNumber / firstNumber;
                    }
                }

            default:
                {
                    throw new InvalidOperationException("Unknown operation");
                }
        }
    }
}