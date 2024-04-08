using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchConsoleApp
{
    public class SearchConsole
    {
        private readonly ISearchEngine _searchEngine;

        public SearchConsole(ISearchEngine searchEngine)
        {
            _searchEngine = searchEngine;
        }

        public void Run()
        {
            _searchEngine.PrintIndexedDocuments();
            while (true)
            {
                Console.WriteLine("\nEnter search term (type 'exit' to quit):");
                string? term = Console.ReadLine();

                if (string.IsNullOrEmpty(term))
                {
                    Console.WriteLine("Error: Invalid input. Exiting...");
                    break;
                }

                if (term.ToLower() == "exit")
                {
                    Console.WriteLine("Exiting...");
                    break;
                }

                List<string> results = _searchEngine.Search(term);
                if (results.Any())
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
    }
}
