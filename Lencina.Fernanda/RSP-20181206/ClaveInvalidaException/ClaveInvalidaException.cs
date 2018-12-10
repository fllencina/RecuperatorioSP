using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions
{
    public class ClaveInvalidaException : Exception
    {
        public ClaveInvalidaException(string mensaje): base(mensaje)
        {
        }
    }
}
