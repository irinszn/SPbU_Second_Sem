using Routers;

if (args.Length != 2)
{
    Console.WriteLine("Incorrect input, enter after -- the path to the input_file and the path to the output_file");
    return 1;
}

if (!File.Exists(args[0]))
{
    Console.WriteLine("There is no such input_file");
    return 1;
}

if (!File.Exists(args[1]))
{
    Console.WriteLine("There is no such output_file");
    return 1;
}

var topology = File.ReadAllText(args[0]);

try
{
    var optimalTopology = MakeTopology.BuildOptimalTopology(topology);

    File.WriteAllText(args[1], optimalTopology);

    Console.WriteLine($"Optimal topology in {args[1]} file");
}
catch (ArgumentException e)
{
    Console.WriteLine(e.Message);
    return 1;
}
catch (DisconnectedGraphException e)
{
    Console.Error.WriteLine(e.Message);
    return 1;
}

return 0;