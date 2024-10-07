using System.ComponentModel.DataAnnotations.Schema;

namespace DemoBanQuanAo.Models
{
    public class BillDetail
    {
        public string Id { get; set; }

        [ForeignKey("ProductDetail")]
        public string ProductDetailId { get; set; }

        [ForeignKey("Bill")]
        public string BillId { get; set; }

        public decimal DonGia { get; set; }
        public int SoLuong { get; set; }

        public Bill Bill { get; set; }
        public ProductDetail ProductDetail { get; set; }
    }
}
