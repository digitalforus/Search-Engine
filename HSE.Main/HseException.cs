using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSE.Main
{

    [Serializable]
    public class HseException : Exception
    {
        public HseException() { }
        public HseException(string message) : base(message) { } 
    }
}
