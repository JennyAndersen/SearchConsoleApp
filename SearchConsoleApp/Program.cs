using SearchConsoleApp;

internal class Program
{
    static void Main(string[] args)
    {
        InvertedIndex searchEngine = new InvertedIndex();
        searchEngine.IndexDocument("the brown fox jumped over the brown dog");
        searchEngine.IndexDocument("the lazy brown dog sat in the corner");
        searchEngine.IndexDocument("the red fox bit the lazy dog");

        bool continueSearching = true;
        while (continueSearching)
        {
            Console.WriteLine("\nEnter search terms separated by spaces (type 'exit' to quit):");
            string input = Console.ReadLine().ToLower();

            if (input == "exit")
            {
                Console.WriteLine("Exiting...");
                break;
            }

            string[] terms = input.Split(' ');
            List<string> results = searchEngine.Search(terms);
            if (results.Count > 0)
            {
                Console.WriteLine("Matching documents:");
                foreach (var doc in results)
                {
                    Console.WriteLine(doc);
                }
            }
            else
            {
                Console.WriteLine("No matching documents found.");
            }
        }
    }