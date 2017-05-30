using Model.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LuizCarlos.Models
{
    public class CategoryListAPIModel : APIModel
    {
        // { Message: "OK", Result: [{},{}] }
        public List<Category> Result
        { get; set; }
    }

    public class CategoryAPIModel : APIModel
    {
        // { Message: "OK", Result: {} }
        public Category Result
        { get; set; }
    }
}