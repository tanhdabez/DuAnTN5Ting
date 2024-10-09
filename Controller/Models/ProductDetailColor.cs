using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoBanQuanAo.Models
{
    public class ProductDetailColor
    {
        public string Id { get; set; }

        [ForeignKey("ProductDetail")]
        public string ProductDetailId { get; set; }

        [ForeignKey("Color")]
        public string ColorId { get; set; }

        public ProductDetail ProductDetail { get; set; }
        public Color Color { get; set; }
    }
}
