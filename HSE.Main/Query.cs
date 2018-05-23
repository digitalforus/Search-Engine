using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HSE.Base;
using System.Diagnostics.Contracts;

namespace HSE.Main
{
    public class Query
    {
        private string query_input;
        private List<string> terms;
        private string query_type; 
        public Query(string input)
        {
            Contract.Requires(input != null);
            query_input = input;
            terms = new List<string>();
            processQuery();
        }

        public List<string> Terms { get { return terms; } }

        public string QueryType { get { return query_type; } }

        private void processQuery()
        {
            Parser parse = new Parser(query_input);
            terms = parse.ParsedWord;
            query_type = get_query_type();
        }

        private string get_query_type()
        {
            query_input = query_input.ToLower();
            string qt = "";
            if (query_input.Contains('"'))
            {
                qt = "PQ";
            }
            else if((query_input.Split(Breakers.Delimiters)).Length > 1)
            {
                qt = "FTQ";
            }
            else if((query_input.Contains("type:")) || (query_input.Contains("type :")))
            {
                qt = "TQ";
            }
            else
            {
                qt = "OWQ";
            }
            return qt;
        }


         
    }
}
