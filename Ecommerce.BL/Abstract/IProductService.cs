using Ecommerce.Entity.Concrete;
using System.Collections.Generic;

namespace Ecommerce.BL.Abstract
{
    public interface IProductService
    {
        void Add(Product product);
        void Update(Product product);
        void Delete(Product product);
        List<Product> GetAll();
        Product Get(int id);
    }
}
