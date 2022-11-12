using Ecommerce.Entity.Concrete;
using System.Collections.Generic;

namespace Ecommerce.Entity.Abstract
{
    public interface ICategory : IEntity
    {       
        public int Id { get; set; }                
       
        public string Name { get; set; }

        public string Description { get; set; }

        public ICollection<Product> Products { get; set; }  

    }
}
