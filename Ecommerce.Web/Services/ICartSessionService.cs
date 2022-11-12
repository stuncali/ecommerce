using Ecommerce.Web.Entities;

namespace Ecommerce.Web.Services
{
    public interface ICartSessionService
    {
        Cart GetCart();

        void SetCart(Cart cart);
    }
}
