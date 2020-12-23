using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Areas.Admin.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Display(Name = "Tên danh mục sản phẩm")]
        public string Name { get; set; }
        [Display(Name = "Loại sản phẩm")]
        [ForeignKey("ProductTypeId")]
        public int ProductTypeId { get; set; }
        public List<Product> ProductList { get; set; }
        public virtual ProductType ProductType { get; set; }
    }
}
