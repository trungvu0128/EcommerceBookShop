using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Areas.Admin.Models;

namespace WebApp.Models
{
    public class ViewModel
    {
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<Slide> Slides { get; set; }
        public IEnumerable<DetailBill> detailBills{ get; set; }
    }
}
