﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.Orders.Infrastructure
{
    public class OrderDomainException : Exception
    {
        public OrderDomainException()
        { }

        public OrderDomainException(string message)
            : base(message)
        { }

        public OrderDomainException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
