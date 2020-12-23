using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class ExportProduct
    {
        public int Id { get; set; }
        [Display(Name = "Mã sản phẩm")]
        public int IdProduct { get; set; }
        [Display(Name = "Số lượng")]
        public int Quantity { get; set; }
        [Display(Name = "Thời gian")]
        public DateTime Date { get; set; }
        [Display(Name = "Tổng tiền")]
        public decimal Total { get; set; }
    }
}
