using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HSE.Base;
using System.Diagnostics.Contracts;

namespace HSE.Main
{
    public class IndexReader
    {
        private DirectoryInfo dirToGet;
        private Reader read;
        public IndexReader(DirectoryInfo dirToGet)
        {
            Contract.Requires(dirToGet != null);
            this.dirToGet = dirToGet;
            read = new Reader(dirToGet);
        }

        public Reader Read { get { return read; } }

        






    }
}
