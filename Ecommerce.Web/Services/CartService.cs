using Ecommerce.Web.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Ecommerce.Web.Services
{
    public class CartService : ICartService
    {
        public void AddToCard(Cart cart, ProductItem product)
        {
            CartItem cartItem = cart.CartItems.FirstOrDefault(p => p.Product.Id == product.Id);
            if(cartItem != null)
            {
                cartItem.Quantity++;
                return;
            }

            cart.CartItems.Add(new CartItem { Product=product,Quantity=1 });
                
        }

        public List<CartItem> List(Cart cart)
        {
            return cart.CartItems;
        }

        public void RemoveFromCart(Cart cart, int productId)
        {
            cart.CartItems.Remove(cart.CartItems.FirstOrDefault(p=>p.Product.Id == productId));
        }
    }
}
