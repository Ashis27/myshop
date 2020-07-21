using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.Identity.Infrastructure
{
    public class UserDomainException:Exception
    {
        public UserDomainException()
        { }

        public UserDomainException(string message)
            : base(message)
        { }

        public UserDomainException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
