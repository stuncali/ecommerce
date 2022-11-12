using Ecommerce.Entity.Abstract;
using Ecommerce.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualBasic;
using System.IO;

namespace Ecommerce.DAL.Concrete
{
    public class EcommerceContext : DbContext   
    {
        string _connStr;       

        public EcommerceContext()
        {
          
        }
        
        public EcommerceContext(string connStr)
        {           
            _connStr = connStr;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (string.IsNullOrEmpty(_connStr))
            {
                IConfigurationBuilder builder = new ConfigurationBuilder();
                builder.AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json"));
                _connStr = builder.Build().GetConnectionString("connStr");
            };
            optionsBuilder.UseSqlServer(_connStr);
        }

       
        public DbSet<Product> Products { get; set; }
        
        public DbSet<Category> Categories { get; set; }
    }
}
