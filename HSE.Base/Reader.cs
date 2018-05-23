using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HSE.Locale;

namespace HSE.Base
{
    public class Reader
    {
        Dictionary<string, List<int>> posting;
        List<int> list;
        public Reader(DirectoryInfo dirToRead)
        {
            ForwardIndex.load(dirToRead);
            InertedIndex.load(dirToRead);
            
        }

        public Dictionary<string, PostingLists> GetInvertedIndexTable
        {
            get { return InertedIndex.InvertedTable; }
        }

        public Dictionary<string, List<string>> GetForwardIndexTable
        {
            get { return ForwardIndex.ForwardTable; }
        }

        public Dictionary<string, List<int>> getPostings(string key)
        {
            posting = new Dictionary<string, List<int>>();
            PostingLists post;
            if (GetInvertedIndexTable.TryGetValue(key, out post))
            {
                foreach(KeyValuePair<string, List<int>> kv in post)
                {
                    posting.Add(kv.Key, kv.Value);
                } 
            }
            return posting;
        }

        public List<int> GetListings(string doc, string term)
        {
            posting = new Dictionary<string, List<int>>();
            PostingLists post;
            list = new List<int>();
            if (GetInvertedIndexTable.TryGetValue(term, out post))
            {
                if (post.TryGetValue(doc, out list))
                {

                }
            }
            return list;
        }
    }
}
