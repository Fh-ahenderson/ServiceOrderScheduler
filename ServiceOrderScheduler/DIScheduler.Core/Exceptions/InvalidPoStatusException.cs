using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIScheduler.Core.Exceptions
{
    public class InvalidPoStatusException : SapphireDataException
    {
        public InvalidPoStatusException(string message = "Invalid Status for Service Order") : base(message)
        {

        }

    }
}
