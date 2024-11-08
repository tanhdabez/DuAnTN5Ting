using System.ComponentModel.DataAnnotations.Schema;

namespace DemoBanQuanAo.Models
{
    public class CartDetail
    {
        public string Id { get; set; }

        [ForeignKey("ProductDetail")]
        public string ProductDetailId { get; set; }

        [ForeignKey("Cart")]
        public string CartId { get; set; }

        public decimal DonGia { get; set; }
        public int SoLuong { get; set; }

        public Cart Cart { get; set; }
        public ProductDetail ProductDetail { get; set; }
    }
}
