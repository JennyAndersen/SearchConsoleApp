using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchConsoleApp
{
    public class DocumentIndexer : IDocumentIndexer
    {
        public void IndexDocuments(ISearchEngine searchEngine)
        {
            searchEngine.IndexDocument("the brown fox jumped over the brown dog");
            searchEngine.IndexDocument("the lazy brown dog sat in the corner");
            searchEngine.IndexDocument("the red fox bit the lazy dog");
        }
    }
}
