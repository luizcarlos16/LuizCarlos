using Persistence.Contexts;
using Model.Registers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Persistence.DAL.Registers
{
    public class ProductsDAL
    {
        private EFContexts context = new EFContexts();
        public IEnumerable<Product>
            GetOrderByName()
        {
            return context.Products.Include(p => p.Category)
                .Include(p => p.Supplier)
                .OrderBy(p => p.Name);
        }
        public Product ById(long id)
        {
            return context.Products
                .Where(p => p.ProductID == id)
                .Include(p => p.Category)
                .Include(p => p.Supplier)
                .First();
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
