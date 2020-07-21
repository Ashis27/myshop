using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.Payment
{
    public class PaymentSetting
    {
        public bool PaymentSucceeded { get; set; }
        public string EventBusConnection { get; set; }
    }
}
