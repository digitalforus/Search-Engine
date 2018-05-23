using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HSE.Locale;
using System.IO;

namespace HSE.Base
{
    public class Indexer
    {
        private static DirectoryInfo DirectoryToSave;
        public Indexer(DirectoryInfo dirToSave)
        {
            DirectoryToSave = dirToSave;
            ForwardIndex.load(DirectoryToSave);
        }

        public void index(string fileName, List<string> words)
        {
            ForwardIndex.ForwardTable.Add(fileName, words);
        }

        public void close()
        {
            ForwardIndex.serialize(DirectoryToSave);
            ForwardToInverted.Index(DirectoryToSave);
        }
    }


    public class InvertedToForward
    {

    }

    public class ForwardToInverted
    {
        public static void Index(DirectoryInfo dirToSave)
        {
            InertedIndex.load(dirToSave);
            foreach (KeyValuePair<string, List<string>> entry in ForwardIndex.ForwardTable)
            {
                List<string> words = entry.Value;
                int pos = 0;

                foreach (string w in words)
                {
                    pos++;


                    if (InertedIndex.InvertedTable.TryGetValue(w, out PostingLists postings))
                    {
                        if (postings.TryGetValue(entry.Key, out List<int> positions))
                        {
                            positions.Add(pos);
                        }
                        else
                        {
                            postings.Add(entry.Key, new List<int> { pos });
                        }

                    }
                    else
                    {
                        InertedIndex.InvertedTable.Add(w, new PostingLists(entry.Key, pos));
                    }

                }

            }
            InertedIndex.serialize(dirToSave);
        }
    }
}
