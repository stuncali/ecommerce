using Ecommerce.BL.Abstract;
using Ecommerce.DTO.Concerete.Product;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Ecommerce.API.Controllers
{
    [Route("api/{controller}")]
    public class ProductController : ControllerBase
    {
        IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        /// <summary>
        /// Tüm ürünleri kategorileri ile birlikte gösterir.
        /// </summary>
        /// <returns></returns>
        public object Get()
        {
            var products= _productService.GetAll().Select(p => new ProductItemDTO
            {
                Id = p.Id,
                Name = p.Name,
                Category = p.Category.Name,
                Price = p.Price,
                Stock = p.Stock
            }).ToList();

            var jsonData = new
            {
                recordsFiltered = products.Count,
                recordsTotal = products.Count,
                data = products.OrderBy(p => p.Category).ToList()
            };
            return jsonData;
        }

        /// <summary>
        /// Ürünün stok değeri 0 dan büyükse 1 değilse 0 değerini getirir.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public int Get(int id)
        {
            var product = _productService.Get(id);
            return product.Stock > 0 ? 1 : 0;
        }      
    }
}
