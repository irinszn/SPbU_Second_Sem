namespace LZW;

public static class LZWTransform
{
    public static float TransformToZipped(string filePath)
    {
        if (!File.Exists(filePath))
        {
            throw new ArgumentException("There is no file with this path", nameof(filePath));
        }

        var fileOfBytes = File.ReadAllBytes(filePath);

        if (fileOfBytes == null || !fileOfBytes.Any())
        {
            throw new ArgumentException("Trying to compress empty file", nameof(filePath));
        }

        var newFilePath = filePath + ".zipped";

        var text = new LZWEncoder();

        File.WriteAllText(newFilePath, text.Encode(fileOfBytes));

        var SizeOfOriginalFile = new FileInfo(filePath).Length;
        var SizeOfNewFile = new FileInfo(newFilePath).Length;
    
        return (float)SizeOfOriginalFile / SizeOfNewFile;
    }


    public static void TransformToOriginal(string filePath)
    {
        if (!File.Exists(filePath))
        {
            throw new ArgumentException("There is no file with this path", nameof(filePath));
        }

        var encodedFile = File.ReadAllText(filePath);

        if (encodedFile == null || !encodedFile.Any())
        {
            throw new ArgumentException("Trying to decompress empty file", nameof(filePath));
        }

        var encodedArray = encodedFile.Split(" ");

        var newFilePath = filePath.Substring(0, filePath.LastIndexOf('.'));

        var decodeText = new LZWDecoder();

        File.WriteAllBytes(newFilePath, decodeText.Decode(encodedArray));
    }
}
