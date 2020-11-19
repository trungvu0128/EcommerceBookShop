using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace WebApp.Areas.Admin.Models
{
    public class Product
    {
        public int id { get; set; }
        [Required]
        public string Name { get; set; }
        public int UnitPrice { get; set; }
        public string Author { get; set; }
        public int PublisherId { get; set; }
        [ForeignKey("PubisherId")]
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public virtual Category Type { get; set; }
        public virtual Publisher Publishing { get; set; }
    }
}
