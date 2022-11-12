using System.Collections.Generic;
using System.Linq;

namespace Ecommerce.Web.Entities
{
    public class Cart
    {
        public Cart()
        {
            CartItems = new List<CartItem>();
        }

        public List<CartItem> CartItems { get; set; }

        public int Total
        {
            get
            {
                return CartItems.Sum(p => p.Product.Price * p.Quantity);
            }
        }
    }
}
