using SearchConsoleApp;

class Program
{
    static void Main(string[] args)
    {
        ISearchEngine searchEngine = new InvertedIndex();
        IDocumentIndexer documentIndexer = new DocumentIndexer();
        documentIndexer.IndexDocuments(searchEngine);

        var searchConsole = new SearchConsole(searchEngine);
        searchConsole.Run();
    }
}
