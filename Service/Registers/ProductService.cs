using Persistence.DAL.Registers;
using Model.Registers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Registers
{
    public class ProductService
    {
        private ProductsDAL dal = new ProductsDAL();
        public IEnumerable<Product>
        GetOrderedByName()
        {
            return dal.GetOrderByName();
        }
        public Product ById(long id)
        {
            return dal.ById(id);
        }
        public void Save(Product product)
        {
            dal.Save(product);
        }
        public Product Delete(long id)
        {
            return dal.Delete(id);
        }
    }
}