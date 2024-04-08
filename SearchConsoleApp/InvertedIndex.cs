namespace SearchConsoleApp
{
    public class InvertedIndex
    {
        private Dictionary<string, List<string>> index;

        public InvertedIndex()
        {
            index = new Dictionary<string, List<string>>();
        }

        public void IndexDocument(string document)
        {
            var words = document.Split(new char[] { ' ', ',', '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var word in words)
            {
                if (!index.ContainsKey(word))
                {
                    index[word] = new List<string>();
                }
                index[word].Add(document);
            }
        }

        public List<string> Search(string term)
        {
            if (index.ContainsKey(term))
            {
                var documents = index[term];
                var tfidfDictionary = new Dictionary<string, double>();
                foreach (var doc in documents)
                {
                    var words = doc.Split(new char[] { ' ', ',', '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
                    var tf = (double)words.Count(w => w.Equals(term, StringComparison.OrdinalIgnoreCase)) / words.Length;
                    var idf = Math.Log(index.Count / (double)index[term].Count);
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
    }
}

