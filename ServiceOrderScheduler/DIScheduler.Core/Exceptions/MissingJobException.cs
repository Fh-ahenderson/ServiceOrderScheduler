using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIScheduler.Core.Exceptions
{
    public class MissingJobException : SapphireDataException
    {
        public MissingJobException(string message = "Job Missing for Service Order") : base(message)
        {

        }
    }
}
