using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIScheduler.Core.Exceptions
{
    public class SapphireDataException : Exception
    {
        public SapphireDataException(string message) : base(message) { }
    }
}
