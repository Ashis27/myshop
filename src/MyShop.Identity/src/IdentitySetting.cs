using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.Identity
{
    public class IdentitySetting
    {
        public bool UseCustomizationData { get; set; }

        public string ConnectionString { get; set; }

        public string EventBusConnection { get; set; }

        public int CheckUpdateTime { get; set; }
    }
}
