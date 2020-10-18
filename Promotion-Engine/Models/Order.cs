using System;
using System.Collections.Generic;
using System.Text;

namespace Promotion_Engine.Models
{
    class Order
    {
        public int OrderID { get; set; }
        public List<Product> Products { get; set; }

        public Order(int orderid, List<Product> products)
        {
            this.OrderID = orderid;
            this.Products = products;
        }
    }
}
