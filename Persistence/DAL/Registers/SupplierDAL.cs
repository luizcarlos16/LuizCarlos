using Model.Registers;
using Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.DAL.Registers
{
    public class SupplierDAL
    {
        private EFContexts context = new EFContexts();

        public IQueryable<Supplier> GetSuppliersClassifiedsByName()
        {
            return context.Suppliers.OrderBy(b => b.Name);
        }

        public IEnumerable<Supplier> getOrderByName()
        {
            throw new NotImplementedException();
        }
    }
}