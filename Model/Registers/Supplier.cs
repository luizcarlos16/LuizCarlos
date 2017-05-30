using System;
using System.Collections.Generic;
using Model.Registers;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Model.Registers
{
    public class Supplier
    {
        public long SupplierID { get; set; }
        public string Name { get; set; }
        [NotMapped]
        public virtual ICollection<Product> Products { get; set; }
    }
}