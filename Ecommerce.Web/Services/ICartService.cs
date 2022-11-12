using Ecommerce.Web.Entities;
using System.Collections.Generic;

namespace Ecommerce.Web.Services
{
    public interface ICartService
    {
        void AddToCard(Cart cart, ProductItem product);

        void RemoveFromCart(Cart cart,int productId);

        List<CartItem> List(Cart cart);
    }
}
