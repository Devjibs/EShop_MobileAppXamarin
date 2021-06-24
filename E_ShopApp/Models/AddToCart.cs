using System;
using System.Collections.Generic;
using System.Text;

namespace E_ShopApp.Models
{
    public class AddToCart
    {
        public string Price { get; set; }
        public string Qty { get; set; }
        public string TotalAmount { get; set; }
        public int ProductId { get; set; }
        public int CustomerId { get; set; }

    }
}
