using Persistence.DAL.Tables;
using Model.Registers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistence.DAL.Registers;

namespace Service.Registers
{
    public class SupplierService
    {
        private SupplierDAL dal = new SupplierDAL();
        public IEnumerable<Supplier>
        GetOrderedByName()
        {
            return dal.getOrderByName();
        }
    }
}