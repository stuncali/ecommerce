using Ecommerce.BL.Abstract;
using Ecommerce.DAL.Abstract;
using Ecommerce.Entity.Concrete;
using System.Collections.Generic;

namespace Ecommerce.BL.Concrete
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryDAL _categoryDAL;
        
        public CategoryService(ICategoryDAL categoryDAL) { 
          
            _categoryDAL = categoryDAL;
        }

        public void Add(Category category)
        {
            _categoryDAL.Add(category);
        }

        public void Delete(Category category)
        {
            _categoryDAL.Delete(category);
        }

        public Category Get(int id)
        {            
            return _categoryDAL.Get(p => p.Id == id);
        }

        public List<Category> GetAll()
        {            
            return _categoryDAL.GetList();
        }

        public List<Category> GetItems()
        {
            return _categoryDAL.GetItems();   
        }

        public void Update(Category category)
        {
            _categoryDAL.Update(category);
        }
               
    }
}
