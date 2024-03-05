namespace StackCalculator;

public class PolishCalculator
{
    private readonly IStack stack;

    public PolishCalculator(IStack? stack)
    {
        this.stack = stack ?? throw new NullReferenceException("Can't be null");
    }

    public bool IsSign(string element) => element == "+" || element == "-" || element == "*" || element == "=";

    public string [] CheckString (string? InputString)
    {

        if (InputString == null || InputString == string.Empty)
        {
            throw new NullReferenceException("String can't be empty or null");
        }

        var stringArray = InputString.Split(' ');

        if (! int.TryParse(stringArray[0], out var _))
        {
            throw new InvalidOperationException("Incorrect input");
        }

        int digitCount = 0;
        int operationCount = 0;
        
        foreach (var element in stringArray)
        {
            bool isDigit = int.TryParse(element, out var _);

            if (isDigit)
            {
                digitCount++ ;
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

    public float CalculateExpression(string? InputString)
    {
        string [] StringArray = CheckString(InputString);

        foreach (string element in StringArray)
        {
            
            bool isDigit = int.TryParse(element, out var number);

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

    public float TransformValue(float FirstNumber, float SecondNumber, char Operation)
    {
        const float NullConst = 0.01e-4F;

        switch (Operation)
        {
            case '+':
                return FirstNumber + SecondNumber;
            
            case '-':
                return SecondNumber - FirstNumber;

            case '*':
                return FirstNumber * SecondNumber;
            
            case '/':
                {
                    if (Math.Abs(SecondNumber) < NullConst)
                    {
                        throw new InvalidOperationException("Division by zero");
                    }

                    else 
                    {
                        return SecondNumber / FirstNumber;
                    }

                }
                
            default:
            {
                throw new InvalidOperationException("Unknown operation");
            }
        }
    }
}