using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class ExportProduct
    {
        public int Id { get; set; }
        public int IdProduct { get; set; }
        public int Quantity { get; set; }
        public DateTime Date { get; set; }
        public decimal Total { get; set; }
    }
}
