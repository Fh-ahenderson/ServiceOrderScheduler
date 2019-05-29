using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIScheduler.Core.Exceptions
{
    public class MissingActivityException : SapphireDataException
    {
        public MissingActivityException(string message = "Activity Missing for Service Order") : base(message)
        {

        }
    }
}
