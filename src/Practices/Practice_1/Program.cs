//using static System.Console;
//using static System.Math;
//System.Console.WriteLine("Hello, World!");
//System.Console.WriteLine("I like C#");

/*
int[] a = new int[] {1,2,3,4,5};
for (int i = 0;i<a.Length;++i)
{
    a[i] = i;
}

for (int i = 0; i < a.Length; ++i)
{
    System.Console.WriteLine(a[i]);
}
*/

int[] sortingArray = new int[] { -10, 15, 5, 30, 7 };

void BubbleSort(int[] sortingArray)
{
    for (int i = 0; i < sortingArray.Length; ++i)
    {
        for (int j = 1; j < sortingArray.Length - i; ++j)
        {
            if (sortingArray[j - 1] > sortingArray[j])
            {
                (sortingArray[j - 1], sortingArray[j]) = (sortingArray[j], sortingArray[j-1]);
            }
        }
    }
    foreach (var element in sortingArray)
    {
        Console.Write($"{element} ");
    }
}

//BubbleSort(sortingArray);

int[,] sortingArrayTwo = new int[,]
{
    {1,3,2},
    {2,1,1},
    {2,3,2},
    {1,1,1}
};

void BubbleSortTwo(int[,] sortingArrayTwo)
{
    for (int i = 0; i < sortingArrayTwo.GetLength(1); ++i)
    {
        for (int j = 1; j < sortingArrayTwo.GetLength(1); ++j)
        {
            if (sortingArrayTwo[0,j-1] > sortingArrayTwo[0,j])
            {
                for (var k = 0; k< sortingArrayTwo.GetLength(0);++k)
                {
                    (sortingArrayTwo[k, j - 1], sortingArrayTwo[k, j]) = (sortingArrayTwo[k, j], sortingArrayTwo[k, j - 1]);
                }
            }
        }
    }
    for (int i = 0; i < sortingArrayTwo.GetLength(0); ++i)
    {
        for (int j = 0; j < sortingArrayTwo.GetLength(1); ++j)
        {
            Console.Write($"{sortingArrayTwo[i,j]} ");
        }
        Console.WriteLine();
    }
}

//BubbleSortTwo(sortingArrayTwo);


int[][] sortArray = new int[][] { new int[] {1,3,2}, new int[] {2,1,1}, new int[] {2,3,2}, new int[] { 1,1,1} };
void Bsort(int[][] sortArray, Func<int, int,bool> compare)
{
    for (int i = 0; i < sortArray[0].Length; ++i)
    {
        for (int j = 1; j < sortArray[0].Length; ++j)
        {
            if (compare(sortArray[0][j - 1], sortArray[0][j]))
            {
                for (var k = 0; k < sortArray.Length; ++k)
                {
                    (sortArray[k][j - 1], sortArray[k][j]) = (sortArray[k][j], sortArray[k][j - 1]);
                }
            }
        }
    }
    for (int i = 0; i < sortArray.Length; ++i)
    {
        for (int j = 0; j < sortArray[0].Length; ++j)
        {
            Console.Write($"{sortArray[i][j]} ");
        }
        Console.WriteLine();
    }
}

Bsort(sortArray, (int a, int b) => (a >= b));