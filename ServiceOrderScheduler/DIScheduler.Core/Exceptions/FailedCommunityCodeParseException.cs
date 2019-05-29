using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIScheduler.Core.Exceptions
{
    public class FailedCommunityCodeParseException : SapphireDataException
    {
        public FailedCommunityCodeParseException(string message = "Community Code Parse Failed") : base(message)
        {

        }
    }
}
