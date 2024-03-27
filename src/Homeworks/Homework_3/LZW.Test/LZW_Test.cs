using LZW;
namespace LZW_Test;

public class Tests
{
   [TestCase("../../../Texts/text.txt")]
   [TestCase("../../../Texts/tiger.jpg")]
   public void ResultOfDecodeOfCompressFileIsEqualToOriginalFile(string filePath)
   {
    var expected = File.ReadAllBytes(filePath);

    LZWTransform.TransformToZipped(filePath);
    LZWTransform.TransformToOriginal(filePath + ".zipped");

    var actual = File.ReadAllBytes(filePath);
    File.Delete(filePath + ".zipped");

    Assert.That(expected, Is.EqualTo(actual));
   }

    [TestCase("../../../Texts/WrongName.txt")]
   public void DecodeNotExistingFileShouldThrowExeption(string filePath)
   {
    Assert.Throws<ArgumentException>(() => LZWTransform.TransformToOriginal(filePath));
   }

   [TestCase("../../../Texts/WrongName.txt")]
   public void EncodeNotExistingFileShouldThrowExeption(string filePath)
   {
    Assert.Throws<ArgumentException>(() => LZWTransform.TransformToZipped(filePath));
   }

   [TestCase("../../../Texts/Empty.txt")]
   public void EncodeEmptyFileShouldThrowExeption(string filePath)
   {
    Assert.Throws<ArgumentException>(() => LZWTransform.TransformToZipped(filePath));
   }

   [TestCase("../../../Texts/Empty.txt")]
   public void DecodeEmptyFileShouldThrowExeption(string filePath)
   {
    Assert.Throws<ArgumentException>(() => LZWTransform.TransformToOriginal(filePath));
   }

}