using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Areas.Admin.Models;

namespace WebApp.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Display(Name = "Tên khách hàng")]
        public string Name { get; set; }
        [Display(Name = "Địa chỉ")]
        public string  Address { get; set; }
        [Display(Name = "Số điện thoại")]
        public string  Phone { get; set; }
        public string  Email { get; set; }
        public List<Bill> Bills { get; set; }
    }
}
