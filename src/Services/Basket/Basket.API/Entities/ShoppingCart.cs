using System.Collections.Generic;
using System.Linq;

namespace Basket.API.Entities
{
    public class ShoppingCart
    {
        public ShoppingCart()
        {
        }

        public ShoppingCart(string userName)
        {
            UserName = userName;
        }

        public string UserName { get; set; }
        public List<ShoppingCartItems> ShoppingCartItemsList { get; set; } = new();

        public decimal TotalPrice
        {
            get { return ShoppingCartItemsList.Sum(item => item.Price); }
        }
    }
}