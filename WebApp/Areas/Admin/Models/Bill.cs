using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Areas.Admin.Models
{
    public class Bill
    {
        public int Id { get; set; }
        public string DateTime { get; set; }
        public int  TotalPrice { get; set; }
        

    }
}
