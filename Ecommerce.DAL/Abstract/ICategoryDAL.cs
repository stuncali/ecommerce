using Ecommerce.Entity.Concrete;
using System.Collections.Generic;

namespace Ecommerce.DAL.Abstract
{
    public interface ICategoryDAL : IEntityRepository<Category>
    {
        List<Category> GetItems();
    }
}
