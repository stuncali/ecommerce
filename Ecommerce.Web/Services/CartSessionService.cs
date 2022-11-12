using Ecommerce.Web.Entities;
using Ecommerce.Web.Extensions;
using Microsoft.AspNetCore.Http;
namespace Ecommerce.Web.Services
{
    public class CartSessionService : ICartSessionService
    {
        IHttpContextAccessor _httpContextAccessor;

        public CartSessionService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public Cart GetCart()
        {
            var cart=_httpContextAccessor.HttpContext.Session.GetObject<Cart>("cart");
            if(cart == null)
            {
                cart = new Cart();
                _httpContextAccessor.HttpContext.Session.SetObject("cart", cart);
            }
            return cart;
        }

        public void SetCart(Cart cart)
        {
            _httpContextAccessor.HttpContext.Session.SetObject("cart", cart);
        }
    }
}
