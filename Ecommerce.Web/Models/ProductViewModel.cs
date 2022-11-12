using Ecommerce.DTO.Concerete.Category;
using Ecommerce.DTO.Concerete.Product;
using System.Collections.Generic;

namespace Ecommerce.Web.Models
{
    public class ProductViewModel : BaseViewModel
    {
        public ProductViewModel()
        {
            Categories=new List<CategoryItemDTO>();
            Product=new ProductDTO();
            Products = new List<ProductItemDTO>();
        }
        
        public ProductDTO Product { get; set; }

        public List<CategoryItemDTO> Categories { get; set; }

        public List<ProductItemDTO> Products { get; set; }

    }
}
