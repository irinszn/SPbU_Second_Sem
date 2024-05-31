using BWT;
 
bool TestSuffmassCreate()
{
    var inputString = new string[] {"abc","ABACABA", "apple"};
    var expected = new string[][] 
    {
    new string[] {"abc", "bca", "cab"}, 
    new string[] {"AABACAB","ABAABAC", "ABACABA", "ACABAAB", "BAABACA", "BACABAA", "CABAABA"},
    new string[] {"apple", "eappl","leapp","pleap","pplea"} 
    };

    for (int i = 0; i < inputString.Length; ++i) 
    {
        var actual = BWTransform.SuffmasCreate(inputString[i]);
        
        if (!Enumerable.SequenceEqual(actual, expected[i]))
        {
            Console.WriteLine("TestSuffmassCreate is failed.");

            return false;
        }
    }

    return true;
}

bool TestTransformBW()
{
    var inputString = new string[] {"ABACABA","apple","colobok23"};
    var expected = new string[] {"BCABAAA","elppa","k2o3oolbc"};

    for (int i = 0; i < inputString.Length; ++i) 
    {
        var actual = BWTransform.TransformBW(inputString[i]);
        
        if (!(actual == expected[i]))
        {
            Console.WriteLine("TestTransformBW is failed.");

            return false;
        }
    }

    return true;
}

bool TestSearchIndex()
{
    var inputString = new string[] {"ABACABA","apple","colobok23"};
    var expected = new int[] {3, 1, 4};

    for (int i = 0; i < 3; ++i)
    {
        var actual = BWTransform.SearchIndex(inputString[i]);

        if (!(actual == expected[i]))
        {
            Console.WriteLine("TestSearchIndex is failed.");

            return false;
        }
    }

    return true;
}

bool TestReverseTransformBW()
{
    var outputString = new string[] {"BCABAAA","elppa","k2o3oolbc"};
    var stringIndex = new int[] {3, 1, 4};
    var expected = new string[] {"ABACABA","apple","colobok23"};

    for (int i = 0; i < 3; ++i)
    {
        var actual = BWTransform.ReverseTransformBW(outputString[i], stringIndex[i]);

        if (!(actual == expected[i]))
        {
            Console.WriteLine("TestReverseTransformBW is failed.");

            return false;
        }
    }

    return true;
}

bool Test()
{
    var testCase = new bool[] {TestSuffmassCreate(), TestTransformBW(), TestSearchIndex(), TestReverseTransformBW()};

    for (int i = 0; i < testCase.Length; ++i)
    {
        if (!testCase[i])
        {
            return false;
        }
    }

    return true;
}

void UserInterface()
{
    Console.WriteLine("This program of BWT. \nInput 1 to direct transform \nInput 2 to reverse transform ");

    switch(Console.ReadLine())
    {
        case "1":
        {
            Console.WriteLine("Input string to BW transform: ");

            var inputString = Console.ReadLine() ?? throw new ArgumentNullException("String can't be null.");

            var transformString = BWTransform.TransformBW(inputString);
            var stringIndex = BWTransform.SearchIndex(inputString);

            Console.WriteLine("Transform string: {0}, {1} ", transformString, stringIndex);

            break;
        }
        case "2":
        {
            Console.WriteLine("Input transform string and the position of the end of the line separated by a space: ");

            var inputBWString = Console.ReadLine() ?? throw new ArgumentNullException("String can't be null.");

            var transformArray = inputBWString.Split(" ");

            var transformString = transformArray[0];

            int stringIndex;

            var result = int.TryParse(transformArray[1], out stringIndex);

            if (!result)
            {
                Console.WriteLine("Error. Position is a number.");
                break;
            }

            Console.WriteLine("Reverse Burrows-Wheeler transform: {0}", BWTransform.ReverseTransformBW(transformString, stringIndex));

            break;
        }
        
        default:
        {
            Console.WriteLine("Incorrect input. Input 1 or 2.");

            break;
        }
    }
}

Console.WriteLine("Initiation tests.");

if (Test())
{
    UserInterface();
}
else 
{
    Console.Write("Test failed.");
}