namespace MapFilterFold;

/// <summary>
/// Class that implement functions Map, Filter, Fold.
/// </summary>
public static class Functions
{
    /// <summary>
    /// Method that converts all list item by expression.
    /// </summary>
    /// <param name="list">Input list.</param>
    /// <param name="func">Function that transforms each element of input list according to the rule.</param>
    /// <typeparam name="T">Type of elements in input list.</typeparam>
    /// <typeparam name="TRes">Type of elements in transformed list.</typeparam>
    /// <returns>New transformed list.</returns>
    public static List<TRes> Map<T, TRes>(List<T> list, Func<T, TRes> func)
    {
        var resultList = new List<TRes>();

        foreach (var element in list)
        {
            resultList.Add(func(element));
        }

        return resultList;
    }

    /// <summary>
    /// Method that filters list items according to the rule.
    /// </summary>
    /// <param name="list">Input list.</param>
    /// <param name="func">Function that compares whether a list item satisfies the specified condition.</param>
    /// <typeparam name="T">Type of elements in input list and result list.</typeparam>
    /// <returns>New filtered list.</returns>
    public static List<T> Filter<T>(List<T> list, Func<T, bool> func)
    {
        var resultList = new List<T>();

        foreach (var element in list)
        {
            if (func(element))
            {
                resultList.Add(element);
            }
        }

        return resultList;
    }

    /// <summary>
    /// Method that evaluates an expression by given list, value and rule.
    /// </summary>
    /// <param name="list">Input list.</param>
    /// <param name="initValue">Initial value.</param>
    /// <param name="func">Functions that takes list element and initial value and returns new value by rule for each element in list.</param>
    /// <typeparam name="T">Type of elements in input list.</typeparam>
    /// <typeparam name="TRes">Type of result value.</typeparam>
    /// <returns>Accumulated value.</returns>
    public static TRes Fold<T, TRes>(List<T> list, TRes initValue, Func<TRes, T, TRes> func)
    {
        var result = initValue;

        foreach (var element in list)
        {
            result = func(result, element);
        }

        return result;
    }
}