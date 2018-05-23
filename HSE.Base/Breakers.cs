using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSE.Base
{
    public class Breakers
    {
        static Breakers()
        {
            addStopWords();
            addLemma();
        }

        private static Dictionary<string, bool> stopWords = new Dictionary<string, bool>();
        private static Dictionary<string, string> lemma = new Dictionary<string, string>();

        public static readonly char[] Delimiters =
        {
            ' ',
            ',',
            ';',
            '.',
            '\n',
            '\r',
            '?',
            '\"',
            '\\',
            '/',
            '(',
            ')',
            ':',
            '@'
        };

        public static Dictionary<string, bool> StopWord { get { return stopWords; } }

        public static Dictionary<string, string> Lemma { get { return lemma; } }

        private static void addStopWords()
        {
            string word;
            bool cons = true;
            string[] stopList;

            var fileStream = new FileStream(@"C:\Users\user\Documents\c# programs\HSE\HSE.files\stopword.txt", FileMode.Open, FileAccess.Read);
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
            {
                word = streamReader.ReadToEnd();
                stopList = word.Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            }

            foreach (string sw in stopList)
            {
                stopWords.Add(sw, cons);
            }

        }

        private static void addLemma()
        {
            string word;
            string[] lemma1;
            string[] lemma2;

            var fileStream = new FileStream(@"C:\Users\user\Documents\c# programs\HSE\HSE.files\lemma.txt", FileMode.Open, FileAccess.Read);
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
            {
                word = streamReader.ReadToEnd();
                lemma1 = word.Split(new[] { "   " }, StringSplitOptions.RemoveEmptyEntries);
                lemma2 = word.Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            }

            for(int i=0; i<lemma1.Length; i++)
            {
                lemma.Add(lemma1[i], lemma2[i]);
            }
        }



    }
}
