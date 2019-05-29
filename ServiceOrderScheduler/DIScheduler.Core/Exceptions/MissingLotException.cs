using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIScheduler.Core.Exceptions
{
    public class MissingLotException : SapphireDataException
    {
        public MissingLotException(string message = "Lot missing for Service Order") : base(message)
        {

        }
    }
}
