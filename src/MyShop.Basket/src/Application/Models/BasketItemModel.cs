using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.Basket.Application.Models
{
    public class BasketItemModel
    {
        public string BuyerId { get; set; }

        public List<BasketItem> BasketItems { get; set; }
    }
}
