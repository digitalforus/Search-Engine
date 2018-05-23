using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HSE.Base;
using System.IO;

namespace HSE.Main
{
    public class IndexWriter
    {
        private Indexer ind;
        public IndexWriter(DirectoryInfo dirToSave)
        {
           ind = new Indexer(dirToSave);
        }


        public void indexDirectory(DocDirectory dir)
        {
            foreach(Document doc in dir.Documents)
            {
                ind.index(doc.FileName, doc.WordList);
            }

            ind.close();
        }


        public void indexDocument(Document doc)
        {
            ind.index(doc.FileName, doc.WordList);
            ind.close();
        }
 
    }
}
