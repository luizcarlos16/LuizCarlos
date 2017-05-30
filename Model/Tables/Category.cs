using Model.Registers;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace Model.Tables
{
    public class Category
    {
        public long CategoryID { get; set; }
        public string Name { get; set; }
        [NotMapped]
        public virtual IEnumerable<Product> Products { get; set; }
    }
}