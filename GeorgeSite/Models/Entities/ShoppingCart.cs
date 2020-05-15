using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeorgeSite.Models.Entities
{
    public class CartCollection
    {
        public CartCollection()
        {
            if (shoppingCarts==null)
            {
                shoppingCarts = new List<ShoppingCart>();
            }
        }

        public static List<ShoppingCart> shoppingCarts { get; set; }
    }

    public class ShoppingCart
    {
        public string UserId { get;  }
        public List<Item> Items { get; set; }

        public double Total { get=>getTotal();  }
        public DateTime dateCreated { get; }
        public ShoppingCart(string UserId, List<ShoppingCart> shoppingCarts)
        {
            this.UserId = UserId;
            dateCreated = DateTime.Now;
            Items = new List<Item>();
            shoppingCarts.Add(this);

        }

        private double getTotal()
        {
            double dTotal = 0;
            foreach (var item in Items)
            {
                dTotal += item.Price;
            }
            return dTotal;
        }
    }
}
