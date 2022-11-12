using Ecommerce.BL.Abstract;
using Ecommerce.DAL.Abstract;
using Ecommerce.Entity.Abstract;
using Ecommerce.Entity.Concrete;
using System.Collections.Generic;

namespace Ecommerce.BL.Concrete
{
    public class ProductService : IProductService
    {
        private readonly IProductDAL _productDAL;
        
        public ProductService(IProductDAL productDAL)
        {
            _productDAL = productDAL;
        }

        public void Add(Product product)
        {
            _productDAL.Add(product);
        }

        public void Delete(Product product)
        {
            _productDAL.Delete(product);
        }

        public Product Get(int id)
        {
            return _productDAL.GetProductWithCategory(id);
        }

        public List<Product> GetAll()
        {            
            return _productDAL.GetProductsWithCategory();
        }

        public void Update(Product product)
        {
            _productDAL.Update(product);
        }
    }
}
