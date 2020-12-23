using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Areas.Admin.Models
{
    public class Publisher
    {
        public int Id { get; set; }
        [Display(Name = "Tên nhà xuất bản")]
        public string  Name { get; set; }
        [Display(Name = "Số điện thoại")]
        public string Phone { get; set; }
        [Display(Name = "Địa chỉ liên hệ")]
        public string Addresss { get; set; }
        public List<Product> Products { get; set; }

    }
}
