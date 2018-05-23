using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSE.Base
{
    public class Parser
    {
        private string words;
        private List<string> extractedwords = new List<string>();
        public Parser(string _query)
        {
            words = _query;
            extractedwords = parse();
        }

        public List<string> ParsedWord
        {
            get
            { 
                return extractedwords;
            }
        }


        private List<string> parse()
        {
            string[] wordArray = Tokenizer.tokenize(words);
            List<string> listArray = new List<string>();

            foreach (string word in wordArray)
            {
                string lword = word.ToLower();
                if (!Breakers.StopWord.ContainsKey(lword))
                {
                    listArray.Add(lword);
                }
            }

            return listArray;
        }

    }




    public class Tokenizer
    {
        public static string[] tokenize(string word)
        {
            string[] extractedText;
            extractedText = word.Split(Breakers.Delimiters, StringSplitOptions.RemoveEmptyEntries);
            return extractedText;
        }
    }
}
