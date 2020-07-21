using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.Identity.Infrastructure
{
    public class IdentityDomainException:Exception
    {
        public IdentityDomainException()
        { }

        public IdentityDomainException(string message)
            : base(message)
        { }

        public IdentityDomainException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
