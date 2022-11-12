using Ecommerce.Entity.Abstract;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.Entity.Concrete
{
    [Table("Categories")]
    public class Category : ICategory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(TypeName = "int")]
        public int Id { get; set; }
                
        [Column(TypeName = "nvarchar(50)")]
        [Required]
        public string Name { get; set; }

        [Column(TypeName ="nvarchar(MAX)")]
        public string Description { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
