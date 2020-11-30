using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

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
        [Display(Name = "Đơn Giá")]
        public int UnitPrice { get; set; }
        [Display(Name = "Tác giả")]
        public string Author { get; set; }
        [Display(Name = "Nhà xuất bản")]
        public int PublisherId { get; set; }
        [ForeignKey("PubisherId")]
        [Display(Name = "Danh mục")]
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        [Display(Name = "Mô tả")]
        public string  Description { get; set; }
        public virtual Category Category { get; set; }
        public virtual Publisher Publishing { get; set; }
    }
}
