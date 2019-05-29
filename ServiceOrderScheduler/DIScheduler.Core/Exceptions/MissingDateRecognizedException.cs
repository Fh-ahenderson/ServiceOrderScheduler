using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIScheduler.Core.Exceptions
{
    public class MissingDateRecognizedException : SapphireDataException
    {
        public MissingDateRecognizedException(string message = "DateRecognized Missing on Service Order") : base(message)
        {

        }
    }
}
