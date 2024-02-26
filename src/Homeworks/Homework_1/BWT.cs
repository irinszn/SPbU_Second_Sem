namespace BWT 
{
    public static class BWTransform
    {
        private static bool LineVerification(string InputString)
        {
            return !string.IsNullOrEmpty(InputString);
        }

        public static string[] SuffmasCreate(string InputString)
        {
            string [] Permutations = new string [InputString.Length];
            Permutations[0] = InputString;
            
            for (int i = 1; i < Permutations.Length; ++i)
            {
                Permutations[i] = Permutations[i - 1].Substring(1) + Permutations[i - 1][0];
            }

            Array.Sort(Permutations);

            return Permutations;
        }

        public static string TransformBW(string InputString)
        {
            if (!LineVerification(InputString))
            {
                Console.WriteLine("Input string can not be empty");
                System.Environment.Exit(0);
            }

            string [] Permutations = SuffmasCreate(InputString);
            string TransformString = string.Empty;

            foreach (var element in Permutations)
            {
                TransformString = TransformString + element[Permutations.Length - 1];
            }

            return TransformString;
        }
        public static int SearchIndex(string InputString)
        {
            string [] Permutations = new string [InputString.Length];
            Permutations = SuffmasCreate(InputString);

            return Array.BinarySearch(Permutations, InputString) + 1;
        }

        public static string ReverseTransformBW(string OutputString, int pos)
        {
            string[] StringTable = new string[OutputString.Length];

            for (int j = 0; j < OutputString.Length; ++j)
            {
                for (int i = 0; i < OutputString.Length; ++i)
                {
                    StringTable[i] = OutputString[i] + StringTable[i];
                }

                Array.Sort(StringTable);
            }

            return StringTable[pos - 1];
        }
    }
}
