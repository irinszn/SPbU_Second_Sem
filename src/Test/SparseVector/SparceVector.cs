namespace SparseVector;

public class Vector
{
    private Dictionary<int, float> vector;

    public Vector()
    {
        this.vector = new Dictionary<int, float>();
    } 

    public void AddCoordinates(int index, float coordinates)
    {
        vector[index] = coordinates;
    }   

    public float GetCordinates(int index)
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

    public bool IfIsNull()
    {
        foreach (var element in vector)
        {
            if (element.Value == 0)
            {
                return false;
            }
        }

        return true;
    }

    public Dictionary<int, float> Sum(Dictionary<int, float> newVector)
    {
        var SumVector = new Dictionary<int, float>();

        foreach (var element in vector)
        {
            SumVector[element.Key] = element.Value;
        }

        foreach (var element in newVector)
        {
            if (!SumVector.ContainsKey(element.Key))
            {
                SumVector[element.Key] = element.Value;
            }
            else
            {
                SumVector[element.Key] += element.Value;
            }
        }

        return SumVector;
    }

    public Dictionary<int, float> Differens(Dictionary<int, float> newVector)
    {
        var DiffVector = new Dictionary<int, float>();

        foreach (var element in vector)
        {
            DiffVector[element.Key] = element.Value;
        }

        foreach (var element in newVector)
        {
            if (DiffVector.ContainsKey(element.Key))
            {
                DiffVector[element.Key] -= element.Value;
            }
        }

        return DiffVector;
    }

    public float ScalarMultiplication(Vector newVector)
    {
        var scalar = 0;

        foreach (var element in vector)
        {
            scalar += element.Value * newVector.GetCordinates(element.Key);
        }

        return scalar;
    }
}