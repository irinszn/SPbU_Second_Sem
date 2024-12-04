namespace Sort;

/// <summary>
/// Class that implements Bubble sort.
/// </summary>
/// <typeparam name="T">Type of elements to sort</typeparam>
public static class BubbleSort<T>
{
    /// <summary>
    /// Method that sorts depending on comparer.
    /// </summary>
    /// <param name="list">Input list.</param>
    /// <param name="comparer">Sorting order.</param>
    /// <returns>Sorted list.</returns>
    public static List<T> Sort(List<T> list, IComparer<T> comparer)
    {
        for (var i = 0; i < list.Count; ++i)
        {
            bool flag = true;
            for (var j = 0; j < list.Count - i - 1; ++j)
            {
                flag = false;
                if (comparer.Compare(list[j], list[j + 1]) > 0)
                {
                    Swap(list, j, j + 1);
                    flag = true;
                }
            }

            if (flag == false)
            {
                break;
            }
        }

        return list;
    }

    /// <summary>
    /// Method that swaps places of two elements.
    /// </summary>
    /// <param name="list">Input list.</param>
    /// <param name="index1">First element.</param>
    /// <param name="index2">Second element.</param>
    private static void Swap(List<T> list, int index1, int index2)
    {
        var temp = list[index1];
        list[index1] = list[index2];
        list[index2] = temp;
    }
}