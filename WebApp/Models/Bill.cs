using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Areas.Admin.Models
{
    public class Bill
    {
        public int Id { get; set; }
        [Display(Name = "Thời gian")]
        public string DateTime { get; set; }
        [Display(Name = "Tổng tiền")]
        public int  TotalPrice { get; set; }
        [Display(Name = "Khách hàng")]
        [ForeignKey("IdCustomer")]
        public int IdCustomer { get; set; }
        public List<DetailBill> DetailBillList{ get; set; }
        public virtual Customer Customer { get; set; }
        public bool status { get; set; }
    }
}
