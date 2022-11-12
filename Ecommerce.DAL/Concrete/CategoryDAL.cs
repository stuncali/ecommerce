using Ecommerce.DAL.Abstract;
using Ecommerce.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Ecommerce.DAL.Concrete
{
    public class CategoryDAL : ICategoryDAL
    {
        private readonly string _connStr;

        public CategoryDAL(string connStr)
        {
            _connStr = connStr;
        }

        public void Add(Category entity)
        {
            using var context = new EcommerceContext(_connStr);
            var addedEntity = context.Entry(entity);
            addedEntity.State = EntityState.Added;
            context.SaveChanges();
        }

        public void Delete(Category entity)
        {
            using var context = new EcommerceContext(_connStr);
            var deleteEntity = context.Entry(entity);
            deleteEntity.State = EntityState.Deleted;
            context.SaveChanges();
        }

        public Category Get(Expression<Func<Category, bool>> filter = null)
        {
            using var context = new EcommerceContext(_connStr);
            return context.Categories.Where(filter).FirstOrDefault();
        }

        public List<Category> GetItems()
        {
            using var context = new EcommerceContext(_connStr);
            return context.Categories.Select(p => new Category
            {
                Id = p.Id,
                Name = p.Name,
            }).ToList();
        }

        public List<Category> GetList(Expression<Func<Category, bool>> filter = null)
        {
            using var context = new EcommerceContext(_connStr);
            return filter == null ? context.Categories.ToList() : context.Categories.Where(filter).ToList();
        }

        public void Update(Category entity)
        {
            using var context = new EcommerceContext(_connStr);
            var updatedEntity = context.Entry(entity);
            updatedEntity.State = EntityState.Modified;
            context.SaveChanges();
        }

    }
}
