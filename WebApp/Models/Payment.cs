using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class Payment
    {
        public int Id { get; set; }
        [Display(Name = "Tên phương thức thanh toán")]
        public string Name { get; set; }
    }
}
