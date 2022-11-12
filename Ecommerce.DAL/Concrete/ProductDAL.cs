using Ecommerce.DAL.Abstract;
using Ecommerce.Entity.Abstract;
using Ecommerce.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Ecommerce.DAL.Concrete
{
    public class ProductDAL : IProductDAL
    {
        private readonly string _connStr;

        public ProductDAL(string connStr)
        {
            _connStr = connStr;
        }

        public void Add(Product entity)
        {
            using var context = new EcommerceContext(_connStr);
            var addedEntity = context.Entry(entity);
            addedEntity.State = EntityState.Added;
            context.SaveChanges();
        }

        public void Delete(Product entity)
        {
            using var context = new EcommerceContext(_connStr);
            var deleteEntity = context.Entry(entity);
            deleteEntity.State = EntityState.Deleted;
            context.SaveChanges();
        }

        public Product Get(Expression<Func<Product, bool>> filter = null)
        {
            using var context = new EcommerceContext(_connStr);
            return context.Products.Where(filter).FirstOrDefault();
        }

        public List<Product> GetList(Expression<Func<Product, bool>> filter = null)
        {
            using var context = new EcommerceContext(_connStr);
            return filter == null ? context.Products.ToList() : context.Products.Where(filter).ToList();
        }

        public List<Product> GetProductsWithCategory()
        {
            using var context = new EcommerceContext(_connStr);
            return context.Products.Include(p=>p.Category).ToList();
        }

        public Product GetProductWithCategory(int id)
        {
            using var context = new EcommerceContext(_connStr);
            return context.Products.Include(p=>p.Category).Where(p=>p.Id==id).FirstOrDefault();
        }

        public void Update(Product entity)
        {
            using var context = new EcommerceContext(_connStr);
            var updatedEntity = context.Entry(entity);
            updatedEntity.State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
