using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class Slide
    {
        public int Id { get; set; }
        [Display(Name = "Hình ảnh")]
        public string  Image { get; set; }
    }
}
