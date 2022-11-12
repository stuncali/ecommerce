using Ecommerce.Entity.Concrete;
using System.Collections.Generic;

namespace Ecommerce.BL.Abstract
{
    public interface ICategoryService
    {
        void Add(Category category);
        void Update(Category category);
        void Delete(Category category);
        List<Category> GetAll();
        Category Get(int id);
        List<Category> GetItems();
    }
}
