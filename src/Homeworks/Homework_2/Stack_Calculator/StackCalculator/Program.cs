using StackCalculator;

Console.WriteLine("Input the expression in the Polish notation (integer number with spaces and operations)");
var inputString = Console.ReadLine();

var arrayStack = new StackArray();
var stackCalculator = new PolishCalculator(arrayStack);

var calculatedExpression = stackCalculator.CalculateExpression(inputString);

Console.WriteLine($"The result of expression (Array-based stack): {calculatedExpression}");


var listStack = new StackList();
stackCalculator = new PolishCalculator(listStack);

calculatedExpression = stackCalculator.CalculateExpression(inputString);

Console.WriteLine($"The result of expression (List-based stack): {calculatedExpression}");
