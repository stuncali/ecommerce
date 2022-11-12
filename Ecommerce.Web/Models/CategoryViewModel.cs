using Ecommerce.DTO.Concerete.Category;
using System.Collections.Generic;

namespace Ecommerce.Web.Models
{
    public class CategoryViewModel : BaseViewModel
    {
        public CategoryViewModel()
        {
            Categories = new List<CategoryDTO>();
            Category=new CategoryDTO();
        }

        public List<CategoryDTO> Categories { get; set; }

        public CategoryDTO Category { get; set; }

    }
}
