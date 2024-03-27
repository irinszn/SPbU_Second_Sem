namespace LZW;

using System.Text;
using PrefixTree;

public class LZWEncoder
{

    private readonly int byteSize = 8;

    public string Encode(byte[] bytesArray)
    {

        if (bytesArray == null)
        {
            throw new ArgumentNullException("Array of bytes can't be null", nameof(bytesArray));
        }

        if (!bytesArray.Any())
        {
            throw new ArgumentException("Array is empty", nameof(bytesArray));
        }

        int currentSize = byteSize;
        int currentMaxNumberOfElements = 256;

        var dictionary = new Trie();

        for (int i = 0; i < 256; i++)
        {
            var newElement = new List<byte>();
            newElement.Add((byte)i);
            dictionary.Add(newElement, i);
        }

        var previousBytes = new List<byte>();

        var result = new StringBuilder();

        foreach (var bytes in bytesArray)
        {
            var elementToAdd = new List<byte>();

            elementToAdd.AddRange(previousBytes);
            elementToAdd.Add(bytes);

            if (dictionary.Contains(elementToAdd))
            {
                previousBytes = elementToAdd;
            }
            else
            {
                if (dictionary.Size == currentMaxNumberOfElements)
                {
                    ++currentSize;
                    currentMaxNumberOfElements *= 2;
                }

                var key = dictionary.GetValue(previousBytes);

                result.Append(key.ToString());
                result.Append(" ");

                previousBytes.Clear();
                previousBytes.Add(bytes);
            }
        }

        var lastKey = dictionary.GetValue(previousBytes);
        result.Append(lastKey.ToString());

        return result.ToString();
    }

}