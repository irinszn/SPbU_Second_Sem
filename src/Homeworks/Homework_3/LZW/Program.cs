using LZW;

if (!(args.Length == 2))
{
    Console.WriteLine("Incorrect input, enter the path to the file and -c to compress it or -u to decompress it");
}

if (args[1] == "-c")
{
    float result;

    try
    {
        result = LZWTransform.TransformToZipped(args[0]);
    }
    catch (ArgumentException)
    {
        Console.WriteLine("Encoding failed");
        return;
    }

    Console.WriteLine($"Compression is successful. Compression ratio is {result * 100}% ");
}
else if (args[1] == "-u")
{
    try
    {
        LZWTransform.TransformToOriginal(args[0]);
    }
    catch (ArgumentException)
    {
        Console.WriteLine("Decoding failed");
        return;
    }

    Console.WriteLine($"Decoding is successful.");
}
else
{
    Console.WriteLine("Incorrect input, enter the path to the file and -c to compress it or -u to decompress it");
}