using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIScheduler.Core.Exceptions
{
    public class MissingCommunityException : SapphireDataException
    {
        public MissingCommunityException(string message = "Community missing for VPO") : base(message)
        {

        }
    }
}
