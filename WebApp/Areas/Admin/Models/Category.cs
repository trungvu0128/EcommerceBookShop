using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Areas.Admin.Models
{
    public class Category
    {
        public int id { get; set; }
        public string Name { get; set; }
        public List<Product> ProductList { get; set; }
    }
}
