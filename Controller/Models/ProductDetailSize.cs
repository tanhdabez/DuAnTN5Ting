using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoBanQuanAo.Models
{
    public class ProductDetailSize
    {
        public string Id { get; set; }

        [ForeignKey("ProductDetail")]
        public string ProductDetailId { get; set; }

        [ForeignKey("Size")]
        public string SizeId { get; set; }


        public ProductDetail ProductDetail { get; set; }
        public Size Size { get; set; }
    }
}
