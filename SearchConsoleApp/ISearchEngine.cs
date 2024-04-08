using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchConsoleApp
{
    public interface ISearchEngine
    {
        void IndexDocument(string document);
        List<string> Search(string term);
        void PrintIndexedDocuments();
    }
}
