using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSE.Main
{
    public class DocDirectory
    {
        private List<Document> documents;
        private DirectoryInfo directory;

        public DocDirectory(DirectoryInfo directory)
        {
            Contract.Ensures(directory != null);
            this.directory = directory; 
            documents = new List<Document>();
            extractFiles(directory);
        }

        public List<Document> Documents
        {
            get
            {
                Contract.Requires(documents != null);
                return documents;
            }
        }

        private void extractFiles(DirectoryInfo directory)
        {
            Contract.Requires(directory != null);
            Contract.Ensures(documents != null);
            foreach(var file in directory.GetFiles())
            {
                documents.Add(new Document(file));
            }
            foreach(var dir in directory.GetDirectories())
            {
                extractFiles(dir);
            }
        }

    }
}
