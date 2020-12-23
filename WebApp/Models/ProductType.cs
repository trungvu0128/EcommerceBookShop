using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Areas.Admin.Models;

namespace WebApp.Models
{
    public class ProductType
    {
        public int Id { get; set; }
        [Display(Name = "Loại sản phẩm")]
        public string Name { get; set; }
        public List<Product> Products  { get; set; }
        public List<Category> Categories { get; set; }
    }
}
