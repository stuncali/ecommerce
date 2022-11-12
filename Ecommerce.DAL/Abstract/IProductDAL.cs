using Ecommerce.Entity.Concrete;
using System.Collections.Generic;

namespace Ecommerce.DAL.Abstract
{
    public interface IProductDAL : IEntityRepository<Product>
    {
        List<Product> GetProductsWithCategory();
        
        Product GetProductWithCategory(int id);

    }
}