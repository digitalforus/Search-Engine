using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSE.Locale
{
    public class PostingLists: IDictionary<string, List<int>>
    {
        Dictionary<string, List<int>> postings;

        public PostingLists(string id, int pos)
        {
            postings = new Dictionary<string, List<int>>();
            postings.Add(id, new List<int>{pos});
        }

        public List<int> this[string key]
        {
            get
            {
                return postings[key];
            }

            set
            {
                postings[key] = value;
            }
        }

        public int Count => postings.Count;

        public bool IsReadOnly => ((IDictionary<string, List<int>>)postings).IsReadOnly;

        public ICollection<string> Keys => ((IDictionary<string, List<int>>)postings).Keys;

        public ICollection<List<int>> Values => ((IDictionary<string, List<int>>)postings).Values;

        public void Add(KeyValuePair<string, List<int>> item)
        {
            ((IDictionary<string, List<int>>)postings).Add(item);
        }

        public void Add(string key, List<int> value)
        {
            postings.Add(key, value);
        }

        public void Clear()
        {
            postings.Clear();
        }

        public bool Contains(KeyValuePair<string, List<int>> item)
        {
            return ((IDictionary<string, List<int>>)postings).Contains(item);
        }

        public bool ContainsKey(string key)
        {
            return postings.ContainsKey(key);
        }

        public void CopyTo(KeyValuePair<string,List<int>>[] array, int arrayIndex)
        {
            ((IDictionary<string, List<int>>)postings).CopyTo(array, arrayIndex);
        }

        public IEnumerator<KeyValuePair<string, List<int>>> GetEnumerator()
        {
            return ((IDictionary<string, List<int>>)postings).GetEnumerator();
        }

        public bool Remove(KeyValuePair<string, List<int>> item)
        {
            return ((IDictionary<string, List<int>>)postings).Remove(item);
        }

        public bool Remove(string key)
        {
            return postings.Remove(key);
        }

        public bool TryGetValue(string key, out List<int> value)
        {
            return postings.TryGetValue(key, out value);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IDictionary<string, List<int>>)postings).GetEnumerator();
        }

        public override string ToString()
        {
            string str = "";
            foreach (var postingsList in postings)
            {
                str += $"{postingsList.Key},{postingsList.Value.Count}: <{postingsList.Value}>\t";
            }
            return str;
        }
    }
}
