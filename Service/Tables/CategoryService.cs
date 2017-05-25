using Model.Tables;
using Persistence.DAL.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Tables
{
public class CategoryService
    {
        private CategoryDAL dal = new CategoryDAL();
        public IEnumerable<Category>
        GetOrderedByName()
        {
            return dal.GetOrderByName();
        }
    }
}