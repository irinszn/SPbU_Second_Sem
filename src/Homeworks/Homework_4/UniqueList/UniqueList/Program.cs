using MyUniqueList;

MyUniqueList<string> fruits = new MyUniqueList<string>() { "apple", "banana", "melon" };

foreach (var fruit in fruits)
{
    Console.WriteLine(fruit);
}