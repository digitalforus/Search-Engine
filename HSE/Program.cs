using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HSE.Main;
using HSE.Locale;
using System.IO;

namespace HSE
{
    class Program
    {
        static void Main(string[] args)
        {
            DocDirectory dir = new DocDirectory(new DirectoryInfo(@"C:\Users\user\Desktop\toUche"));
           
            Console.WriteLine("Indexing...");
            DateTime indexStart = DateTime.Now;
            IndexWriter ind = new IndexWriter(new DirectoryInfo(@"C:\Users\user\Documents\c# programs\HSE\HSE"));
            ind.indexDirectory(dir);
            TimeSpan indexTimeTaken = DateTime.Now.Subtract(indexStart);
            Console.WriteLine($"Time Taken To Index: {indexTimeTaken.Milliseconds} millisecs");

            IndexReader ind2 = new IndexReader(new DirectoryInfo(@"C:\Users\user\Documents\c# programs\HSE\HSE"));
            Console.WriteLine("Enter Query");
            string input = Console.ReadLine();

            DateTime searchStart = DateTime.Now;
            Query query = new Query(input);
            List<string> t = query.Terms;
            foreach(string b in t)
            {
                Console.WriteLine(b);
            }
            Matcher mat = new Matcher(ind2, query);
            
            foreach(string fileName in mat.Results)
            {
                var doc = new Document(new FileInfo(fileName));
                Console.WriteLine(doc.FileName);
            }

            TimeSpan searcTimeTaken = DateTime.Now.Subtract(searchStart);
            Console.WriteLine($"Time Taken To Search: {searcTimeTaken.Milliseconds} millisecs");
            Console.ReadLine();




            
           
           

           
            


        }
    }
}
