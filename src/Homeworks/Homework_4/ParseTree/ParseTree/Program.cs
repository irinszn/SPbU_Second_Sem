using ParseTree;

if (args.Length != 1)
{
    Console.WriteLine("Incorrect input, enter the path to the file");
}

if (!File.Exists(args[0]))
{
    Console.WriteLine("There is no such file");
}

string expression = File.ReadAllText(args[0]);
Console.WriteLine(expression);

var tree = new PTree();

try
{
    tree.BuildTree(expression);
}
catch (ArgumentException e)
{
    Console.WriteLine(e.Message);
    return;
}

float result = 0;
try
{
    result = tree.Calculate();
}
catch (ArgumentException e)
{
    Console.WriteLine(e.Message);
    return;
}

Console.WriteLine($"Parse tree: {tree.GetTree()}");

Console.WriteLine($"The value of parse tree is equal to {result}");
