using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.Basket.Application.Models
{
    public class BasketCheckoutModel
    {
        public string BuyerId { get; set; }

        public string UserName { get; set; }

        public Guid RequestId { get; set; }

        public Address Address { get; set; }

        public PaymentMethod PaymentMethod { get; set; }
    }
}
