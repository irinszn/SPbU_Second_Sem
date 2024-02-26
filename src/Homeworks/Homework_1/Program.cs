using BWT;
 
bool TestSuffmassCreate()
{
    string[] InputString = new string[] {"abc","ABACABA", "apple"};
    string[][] Expected = new string[][] 
    {
    new string[] {"abc", "bca", "cab"}, 
    new string[] {"AABACAB","ABAABAC", "ABACABA", "ACABAAB", "BAABACA", "BACABAA", "CABAABA"},
    new string[] {"apple", "eappl","leapp","pleap","pplea"} 
    };
    bool Passed = true;
    for (int i = 0; i < InputString.Length; ++i) 
    {
        string[] Actual = BWTransform.SuffmasCreate(InputString[i]);
        
        if (!Enumerable.SequenceEqual(Actual, Expected[i]))
        {
            Passed = false;
        }
    }

    return Passed;
}

bool TestTransformBW()
{
    string [] InputString = new string [] {"ABACABA","apple","colobok23"};
    string[] Expected = new string [] {"BCABAAA","elppa","k2o3oolbc"};
    bool Passed = true;
    for (int i = 0; i < InputString.Length; ++i) 
    {
        string Actual = BWTransform.TransformBW(InputString[i]);
        
        if (!(Actual == Expected[i]))
        {
            Passed = false;
        }
    }

    return Passed;
}

bool TestSearchIndex()
{
    string[] InputString = new string [] {"ABACABA","apple","colobok23"};
    int [] Expected = new int [] {3, 1, 4};
    bool Passed = true;
    for (int i = 0; i < 3; ++i)
    {
        int Actual = BWTransform.SearchIndex(InputString[i]);

        if (!(Actual == Expected[i]))
        {
            Passed = false;
        }
    }

    return Passed;
}

bool TestReverseTransformBW()
{
    string [] OutputString = new string [] {"BCABAAA","elppa","k2o3oolbc"};
    int [] StringIndex = new int [] {3, 1, 4};
    string [] Expected = new string [] {"ABACABA","apple","colobok23"};
    bool Passed = true;

    for (int i = 0; i < 3; ++i)
    {
        string Actual = BWTransform.ReverseTransformBW(OutputString[i], StringIndex[i]);

        if (!(Actual == Expected[i]))
        {
            Passed = false;
        }
    }

    return Passed;
}

bool Test()
{
    var TestCases = new bool[] {TestSuffmassCreate(), TestTransformBW(), TestSearchIndex(), TestReverseTransformBW()};
    for (int i = 0; i < TestCases.Length; ++i)
    {
        if (!TestCases[i])
        {
            return false;
        }
    }

    return true;
}

void UserInterface()
{
    Console.Write("Input the string: ");
    string? InputString = Console.ReadLine();
    
    string TransformString = BWTransform.TransformBW(InputString);
    int StringIndex = BWTransform.SearchIndex(InputString);

    Console.WriteLine("Transform string: {0}, {1} ", TransformString, StringIndex);

    Console.WriteLine("Reverse Burrows-Wheeler transform: {0}", BWTransform.ReverseTransformBW(TransformString, StringIndex));
}

Console.WriteLine("Initiation tests");

if (Test())
{
    UserInterface();
}
else 
{
    Console.Write("Test failed");
}