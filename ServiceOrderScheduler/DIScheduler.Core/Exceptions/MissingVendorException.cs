using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIScheduler.Core.Exceptions
{
    public class MissingVendorException : SapphireDataException
    {
        public MissingVendorException(string message = "Vendor missing for Service Order") : base(message)
        {

        }
    }
}
