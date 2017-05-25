using Model.Tables;
using Persistence.Contexts;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Persistence.DAL.Tables
{
    public class CategoryDAL
    {
            private EFContexts context = new EFContexts();

            public IEnumerable<Category>
              GetOrderByName()
            {
                return context
                    .Categories
                    .OrderBy(p => p.Name);
            }
            public Category ById(long id)
            {
                return context.Categories
                    .Where(p => p.CategoryID == id)
                    .Include("Products.Category")
                    .First();
            }

        public void Save(Category category)
        {
            if (category.CategoryID == null)
            {
                context.Categories.Add(category);
            }
            else
            {
                context.Entry(category).State = EntityState.Modified;
            }

            context.SaveChanges();

        }
        public Category Delete(long id)
            {
                var category = ById(id);
                context.Categories.Remove(category);
                context.SaveChanges();
                return category;
            }
        }
    }