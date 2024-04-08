using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchConsoleApp
{
    public interface IDocumentIndexer
    {
        void IndexDocuments(ISearchEngine searchEngine);
    }
}
