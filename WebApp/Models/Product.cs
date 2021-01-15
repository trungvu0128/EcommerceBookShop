using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Areas.Admin.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Tên sản phẩm")]
        public string Name { get; set; }
        [Display(Name = "Hình sản phẩm")]
        public string Img { get; set; }
        [Display(Name = "Nhà cung cấp")]
        public int Origin { get; set; }
        [Display(Name = "Đơn Giá")]
        public int UnitPrice { get; set; }
        [Display(Name = "Tác giả")]
        public string Author { get; set; }

        [ForeignKey("PubisherId")]
        [Display(Name = "Nhà xuất bản")]
        public int PublisherId { get; set; }
        [ForeignKey("CategoryId")]
        [Display(Name = "Danh mục sản phẩm")]
        public int CategoryId { get; set; }

        [ForeignKey("ProductTypeId")]
        [Display(Name = "Loại sản phẩm")]
        public int? ProductTypeId { get; set; }
        [Display(Name = "Mô tả")]
        public string  Description { get; set; }
        [Display(Name = "Trạng thái sản phẩm")]
        public int Level { get; set; }
        [Display(Name = "Danh mục sản phẩm")]
        public virtual Category Category { get; set; }
        [Display(Name = "Nhà xuất bản")]
        public virtual Publisher Publishing { get; set; }
        [Display(Name = "Loại sản phẩm")]
        public virtual ProductType ProductType { get; set; }
    }
}
