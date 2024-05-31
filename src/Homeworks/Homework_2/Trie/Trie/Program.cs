using PrefixTree;

Console.WriteLine("""

                     It is a program to work with trie (prefix tree).

                     Use the action below:
                     0 - Exit
                     1 - Add element
                     2 - Remove element
                     3 - Check if element is in the trie
                     4 - See how many words start with a given prefix
                     5 - Get size of the trie 
                     
                     """);

var trie = new Trie();
var work = true;

while (work)
{
    Console.WriteLine("Input one of the actions 0 - 5: ");
    var action = Console.ReadLine();

    switch (action)
    {
        case "0":
        {
            work = false;
            break;
        }

        case "1":
        {
            Console.WriteLine("Input the word that you want to add: ");
            var word = Console.ReadLine();

            if (word == null)
            {
                Console.WriteLine("Word can't be null");
                break;
            }

            bool isSuccess = trie.Add(word);

            Console.WriteLine(isSuccess ? "Word added" : "Word is already in trie");
            break;
        }

        case "2":
        {
            Console.WriteLine("Input the word that you want to remove from trie: ");
            var word = Console.ReadLine();

            if (word == null)
            {
                Console.WriteLine("Word can't be null");
                break;
            }

            bool isSuccess = trie.Remove(word);

            Console.WriteLine(isSuccess ? "Word removed" : "No such word in trie");
            break;
        }

        case "3":
        {
            Console.WriteLine("Input the word that you want to check for: ");
            var word = Console.ReadLine();

            if (word == null)
            {
                Console.WriteLine("Word can't be null");
                break;
            }

            bool isSuccess = trie.Contains(word);

            Console.WriteLine(isSuccess ? "Word found" : "No such word in trie");
            break;
        }

        case "4":
        {
            Console.WriteLine("Input the prefix: ");
            var prefix = Console.ReadLine();

            if (prefix == null)
            {
                Console.WriteLine("Prefix can't be null");
                break;
            }

            Console.WriteLine($"{trie.HowManyStartsWithPrefix(prefix)} elements starts with {prefix}");
            break;
        }

        case "5":
        {
            Console.WriteLine($"Trie size: {trie.Size}");
            break;
        }

        default:
            Console.WriteLine("There is no such number");
            break;
    }
}
