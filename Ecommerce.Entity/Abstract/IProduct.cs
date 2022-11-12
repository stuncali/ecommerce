using Ecommerce.Entity.Concrete;

namespace Ecommerce.Entity.Abstract
{
    public interface IProduct : IEntity
    {
        public int Id { get; set; }
            
        public int CategoryId { get; set; }
             
        public string Name { get; set; }
              
        public int Price { get; set; }
                
        public int Stock { get; set; }

        public Category Category { get; set; }

    }
}
