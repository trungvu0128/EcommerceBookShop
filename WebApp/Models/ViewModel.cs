using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Areas.Admin.Models;

namespace WebApp.Models
{
    public class ViewModel
    {
        public List<Category> Categories { get; set; }
        public List<Product> Products { get; set; }
        public List<Slide> Slides { get; set; }
        public List<DetailBill> detailBills{ get; set; }
        public List <Cart> Carts { get; set; } 
        public Product product { get; set; }
    }
}
