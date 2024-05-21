namespace SparseVector;

/// <summary>
/// Class that implements sparse vector.
/// </summary>
public class Vector
{
    public Dictionary<int, float> vector = new();

    /// <summary>
    /// Add value in sparse vector.
    /// </summary>
    /// <param name="index">Place to add.</param>
    /// <param name="value">Value to add.</param>
    public void AddValue(int index, float value)
    {
        if (value == 0)
        {
            return;
        }
        vector[index] = value;
    }   

    /// <summary>
    /// Get value of vector by index.
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    public float GetValue(int index) => vector.ContainsKey(index) ? vector[index] : 0;

    /// <summary>
    /// Indexator.
    /// </summary>
    public float this[int index]
    {
        get 
        {
           return vector.ContainsKey(index) ? vector[index] : 0;
        }
        set
        {
            if (value == 0)
            {
                return;
            }

            vector[index] = value; ;
        }
    }

    /// <summary>
    /// Checks if sparse vector is null.
    /// </summary>
    /// <returns></returns>
    public bool IfIsNull()
    {
        foreach (var element in vector)
        {
            if (element.Value != 0)
            {
                return false;
            }
        }

        return true;
    }

    /// <summary>
    /// Method that implements addition if two sparse vectors.
    /// </summary>
    /// <param name="newVector">Second vector.</param>
    /// <returns>Result of addition.</returns>
    public Dictionary<int, float> Add(Dictionary<int, float> newVector)
    {
        var sumVector = new Dictionary<int, float>();

        foreach (var element in vector)
        {
            sumVector[element.Key] = element.Value;
        }

        foreach (var element in newVector)
        {
            if (!sumVector.ContainsKey(element.Key))
            {
                sumVector[element.Key] = element.Value;
            }
            else
            {
                sumVector[element.Key] += element.Value;
            }
        }

        return sumVector;
    }

    /// <summary>
    /// Method that implements subtraction if two sparse vectors.
    /// </summary>
    /// <param name="newVector">Second vector.</param>
    /// <returns>Result of subtraction.</returns>
    public Dictionary<int, float> Subtract(Dictionary<int, float> newVector)
    {
        var subVector = new Dictionary<int, float>();

        foreach (var element in vector)
        {
            subVector[element.Key] = element.Value;
        }

        foreach (var element in newVector)
        {
            if (!subVector.ContainsKey(element.Key))
            {
                subVector[element.Key] = -element.Value;
            }
            else
            {
                subVector[element.Key] -= element.Value;
            }
        }

        return subVector;
    }

    /// <summary>
    /// Method that implements scalar multiplication of two sparse vectors.
    /// </summary>
    /// <param name="newVector">Second vector.</param>
    /// <returns>Result of scalar multiplication.</returns>
    public float ScalarMultiplication(Vector newVector)
    {
        float scalar = 0;

        foreach (var element in vector)
        {
            scalar += element.Value * newVector[element.Key];
        }

        return scalar;
    }
}