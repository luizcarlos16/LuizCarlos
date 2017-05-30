using Model.Registers;
using Persistence.Contexts;
using System.Data.Entity;
using System.Linq;
using System;
using System.Collections.Generic;

namespace Persistence.DAL.Registers
{
    public class ProductDAL
    {
        private EFContexts context = new EFContexts();

        public IQueryable<Product> Get()
        {
            return context.Products;
        }

        public IQueryable<Product> GetOrderedByName()
        {
            return context
                .Products
                .Include(p => p.Category)
                .Include(p => p.Supplier)
                .OrderBy(b => b.Name);
        }

        public Product ById(long id)
        {
            return context.Products
                .Where(p => p.ProductID == id)
                .Include(c => c.Category)
                .Include(f => f.Supplier)
                .First();
        }

        public IQueryable<Product> GetByCategory(long categoryId)
        {
            return context
                .Products
                .Where(p => p.CategoryID.HasValue &&
                p.CategoryID.Value == categoryId)
                .Include(f => f.Supplier);
        }

        public void Save(Product product)
        {
            if (product.ProductID == null)
                context.Products.Add(product);
            else
                context.Entry(product).State = EntityState.Modified;

            context.SaveChanges();
        }

        public Product Delete(long id)
        {
            var product = ById(id);

            context.Products.Remove(product);
            context.SaveChanges();

            return product;
        }
    }
}
