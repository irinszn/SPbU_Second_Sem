using StackCalculator;

Console.WriteLine("Input the expression in the Polish notation (integer number with spaces and operations)");
string? InputString = Console.ReadLine();

var arrayStack = new StackArray();
var stackCalculator = new PolishCalculator(arrayStack);

float CalculatedExpression = stackCalculator.CalculateExpression(InputString);

Console.WriteLine($"The result of expression (Array-based stack): {CalculatedExpression}");


var listStack = new StackList();
stackCalculator = new PolishCalculator(listStack);

CalculatedExpression = stackCalculator.CalculateExpression(InputString);

Console.WriteLine($"The result of expression (List-based stack): {CalculatedExpression}");
