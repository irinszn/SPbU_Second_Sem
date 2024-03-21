
namespace LZW;

public class LZWDecoder
{
    public byte [] Decode(string [] encodedArray)
    {
        if (encodedArray[0] == string.Empty)
        {
            throw new ArgumentException("Array is empty", nameof(encodedArray));
        }

        int currentMaxNumber = 256;
        var dictionary = new Dictionary<int, List<byte>> ();

        for (int i = 0; i < 256; i++)
        {
            var newElement = new List<byte>();
            newElement.Add((byte)i);
            dictionary.Add(i, newElement);
        }

        var decodeList = new List<byte>();

        for (var i = 0; i < encodedArray.Length - 1; ++i)
        {
            decodeList.AddRange(dictionary[int.Parse(encodedArray[i])]);

            var newElement = new List<byte> ();

            newElement.AddRange(dictionary[int.Parse(encodedArray[i])]);
            newElement.Add(dictionary[int.Parse(encodedArray[i + 1])][0]);

            dictionary.Add(currentMaxNumber, newElement);

            ++currentMaxNumber;
        }

        decodeList.AddRange(dictionary[int.Parse(encodedArray[encodedArray.Length - 1])]);

        return decodeList.ToArray();
    }
}