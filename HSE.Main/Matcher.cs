using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HSE.Base;
using System.IO;

namespace HSE.Main
{
    public class Matcher 
    {
        private Query query;
        private IndexReader ind;
        private string q_type;
        private List<string> terms;
        private List<string> results = new List<string>();

        public Matcher(IndexReader ind, Query query)
        {
            this.ind = ind;
            this.query = query;
            match();
        }

        public List<string> Results { get { return results; } }

        private void match()
        {
            q_type = query.QueryType;
            terms = query.Terms;

            switch (q_type)
            {
                case "OWQ":
                    owq();
                    break;
                case "FTQ":
                    owq();
                    break;
                case "PQ":
                    pq();
                    break;
            }
        }

        private void owq()
        {
            foreach(string t in terms)
            {
                Dictionary<string, List<int>> post = ind.Read.getPostings(t);
                if(post != null)
                {
                    foreach(KeyValuePair<string, List<int>> kv in post)
                    {
                        results.Add(kv.Key);
                    }
                }
                else
                {
                    throw new HseException("Result not found");
                }
            }
        }

        private void ftq()
        {
            HashSet<string> mainSet = new HashSet<string>();

            foreach (string t in terms)
            {
                HashSet<string> set = new HashSet<string>();
                Dictionary<string, List<int>> post = ind.Read.getPostings(t);
                if (post != null)
                {
                    foreach (KeyValuePair<string, List<int>> kv in post)
                    {
                        set.Add(kv.Key);
                    }
                }
                mainSet.Union<string>(set);
                set.Clear();
            }

            foreach(string val in mainSet)
            {
                results.Add(val);
            }

        }

        private void pq()
        {
            HashSet<string> mainSet = new HashSet<string>();
            
            foreach (string t in terms)
            {
                HashSet<string> set = new HashSet<string>();
                Dictionary<string, List<int>> post = ind.Read.getPostings(t);
                if (post != null)
                {
                    foreach (KeyValuePair<string, List<int>> kv in post)
                    {
                        set.Add(kv.Key);
                    }
                }
                mainSet.IntersectWith(set);
            }

            foreach (string val in mainSet)
            {
                List<List<int>> mainList = new List<List<int>>();
                //List<List<int>> mainList2 = new List<List<int>>();
                foreach (string t in terms)
                {
                    List<int> getList = ind.Read.GetListings(val, t);
                    mainList.Add(getList);
                }

                for(int i=0; i<mainList.Capacity; i++)
                {
                    for(int j=0; j<mainList[i].Capacity; j++)
                    {
                        mainList[i][j] -= i;
                    }
                    mainList[0].Intersect<int>(mainList[i]);
                }

                if(mainList != null)
                {
                    results.Add(val);
                }
            }

        }

    }
}
