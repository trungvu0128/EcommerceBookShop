using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Areas.Admin.Models;

namespace WebApp.Models
{
    public class Cart
    {
        public int Quantity { get; set; } = 1;
        public virtual Product Product { get; set; } 
    }
}
