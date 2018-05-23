using System.IO;
using System.Text;
using TikaOnDotNet.TextExtraction;

namespace HSE.Base
{
    public class Extractor
    {
        public static string readText(FileInfo file)
        {
            string word = "";
            if (file.Extension == ".txt")
            {
                var fileStream = new FileStream(file.FullName, FileMode.Open, FileAccess.Read);
                using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
                {
                    word += streamReader.ReadToEnd();



                }
            }
            else
            {
                var textExtractor = new TextExtractor();
                word = (textExtractor.Extract(file.FullName)).Text;
                
            }

            return word;
        }
    }
}
