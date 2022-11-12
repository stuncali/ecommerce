namespace Ecommerce.Web.Entities
{
    public class CartItem
    {
        public ProductItem Product { get; set; }
        public int Quantity { get; set; }
    }
}
