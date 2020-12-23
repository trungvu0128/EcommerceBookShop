using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class Carrier
    {
        public int Id { get; set; }
        [Display(Name = "Tên nhà vận chuyển")]
        public string Name { get; set; }
    }
}
