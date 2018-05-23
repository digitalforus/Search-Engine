using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSE.Main
{
    public class Control
    {

        public static string DefaultDir = Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);

        private static string customDir = null;
        public static string CustomDir { get { return customDir; } set { customDir = value; } }

       // DocDirectory dir = new DocDirectory(new DirectoryInfo(DefaultDir));
        

    }
}
