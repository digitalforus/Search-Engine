using HSE.Base;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HSE.Main
{
    public class Document
    {
        private FileInfo file;
        private static int fileID = 0;
        private List<string> words;
        
        public Document(FileInfo file)
        {
            Contract.Requires(file != null);
            this.file = file;
            fileID++;
            words = new List<string>();
            extractWords();
        }

        public string FileName { get { return file.FullName; } }

        public string FileExtension { get { return file.Extension; } }

        public int FileID { get { return fileID; } }

        public FileInfo File { get { return file; } }

        public List<string> WordList { get { return words; } }

        private List<string> extractWords()
        {
            Contract.Ensures(words != null);
            string text = Extractor.readText(file);

            Parser parse = new Parser(text);

            words = parse.ParsedWord;

            string[] docName;
            docName = file.FullName.Split(new[] { '\\', '.' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string r in docName)
            {
                words.Add(r);
            }

            return words;
        }
    }
}
