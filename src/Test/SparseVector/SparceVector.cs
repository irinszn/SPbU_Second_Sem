namespace SparseVector;

public class Vector
{
    public Dictionary<int, float> vector = new();

    public void AddValue(int index, float value)
    {
        if (value == 0)
        {
            return;
        }
        vector[index] = value;
    }   

    public float GetValue(int index)
    {
        if (!vector.ContainsKey(index))
        {
            return 0;
        }
        else
        {
            return vector[index];
        }
    }

    public float this[int index]
    {
        get 
        {
            if (!vector.ContainsKey(index))
            {
                return 0;
            }
            else
            {
                return vector[index];
            };
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