namespace BWT
{
    public static class BWTransform
    {
        private static bool LineVerification(string inputString)
        {
            return !string.IsNullOrEmpty(inputString);
        }

        public static string[] SuffmasCreate(string inputString)
        {
            var permutation = new string[inputString.Length];
            permutation[0] = inputString;
            
            for (int i = 1; i < permutation.Length; ++i)
            {
                permutation[i] = permutation[i - 1].Substring(1) + permutation[i - 1][0];
            }

            Array.Sort(permutation);

            return permutation;
        }

        public static string TransformBW(string inputString)
        {
            if (!LineVerification(inputString))
            {
                Console.WriteLine("Input string can not be empty");
                System.Environment.Exit(0);
            }

            var permutation = SuffmasCreate(inputString);
            var transformString = string.Empty;

            foreach (var element in permutation)
            {
                transformString = transformString + element[permutation.Length - 1];
            }

            return transformString;
        }

        public static int SearchIndex(string inputString)
        {
            var permutation = new string [inputString.Length];

            permutation = SuffmasCreate(inputString);

            return Array.BinarySearch(permutation, inputString) + 1;
        }

        public static string ReverseTransformBW(string outputString, int pos)
        {
            var stringTable = new string[outputString.Length];

            for (int j = 0; j < outputString.Length; ++j)
            {
                for (int i = 0; i < outputString.Length; ++i)
                {
                    stringTable[i] = outputString[i] + stringTable[i];
                }

                Array.Sort(stringTable);
            }

            return stringTable[pos - 1];
        }
    }
}
