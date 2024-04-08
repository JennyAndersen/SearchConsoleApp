namespace SearchConsoleApp
{
    public class InvertedIndex : ISearchEngine
    {
        private readonly Dictionary<string, List<string>> _index;

        public InvertedIndex()
        {
            _index = new Dictionary<string, List<string>>();
        }

        public void IndexDocument(string document)
        {
            try
            {
                var words = document.Split(new char[] { ' ', ',', '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var word in words)
                {
                    var cleanedWord = RemoveStopWords(Stem(word.ToLower()));
                    if (!_index.ContainsKey(cleanedWord))
                    {
                        _index[cleanedWord] = new List<string>();
                    }
                    _index[cleanedWord].Add(document);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error indexing document: {ex.Message}");
            }
        }

        public List<string> Search(string term)
        {
            try
            {
                var cleanedTerm = RemoveStopWords(Stem(term.ToLower()));
                if (_index.ContainsKey(cleanedTerm))
                {
                    var documents = _index[cleanedTerm];
                    var tfidfDictionary = new Dictionary<string, double>();
                    foreach (var doc in documents)
                    {
                        var words = doc.Split(new char[] { ' ', ',', '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
                        var tf = (double)words.Count(w => w.Equals(cleanedTerm, StringComparison.OrdinalIgnoreCase)) / words.Length;
                        var idf = Math.Log(_index.Count / (double)_index[cleanedTerm].Count);
                        var tfidf = tf * idf;
                        tfidfDictionary[doc] = tfidf;
                    }
                    return tfidfDictionary.OrderByDescending(pair => pair.Value).Select(pair => pair.Key).ToList();
                }
                else
                {
                    return new List<string>();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error searching term: {ex.Message}");
                return new List<string>();
            }
        }

        public void PrintIndexedDocuments()
        {
            Console.WriteLine("The following documents are indexed:");
            int index = 1;
            var printedDocuments = new HashSet<string>();
            foreach (var (word, documents) in _index)
            {
                foreach (var document in documents)
                {
                    if (!printedDocuments.Contains(document))
                    {
                        Console.WriteLine($"Document {index}: \"{document}\"");
                        printedDocuments.Add(document);
                        index++;
                    }
                }
            }
        }

        private string Stem(string word)
        {
            // Basic stemming: Remove common word endings
            if (word.EndsWith("es") || word.EndsWith("ed"))
            {
                return word.Substring(0, word.Length - 2);
            }
            return word;
        }

        private string RemoveStopWords(string word)
        {
            // Basic stop words removal
            var stopWords = new HashSet<string> { "the", "and", "or", "in", "on", "of", "with" };
            if (stopWords.Contains(word))
            {
                return "";
            }
            return word;
        }
    }
}

