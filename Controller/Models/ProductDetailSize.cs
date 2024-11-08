using System.ComponentModel.DataAnnotations.Schema;

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
