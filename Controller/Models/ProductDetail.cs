using System.ComponentModel.DataAnnotations.Schema;

namespace DemoBanQuanAo.Models
{
    public class ProductDetail
    {
        public string Id { get; set; }

        [ForeignKey("Product")]
        public string ProductId { get; set; }

        public int SoLuong { get; set; }
        public DateTime NgayTao { get; set; }
        public DateTime NgayCapNhat { get; set; }
        public string TrangThai { get; set; }

        public Product Product { get; set; }
        public ICollection<ProductDetailColor> ProductDetailColors { get; set; }
        public ICollection<ProductDetailSize> ProductDetailSizes { get; set; }
        public ICollection<CartDetail> CartDetails { get; set; }
        public ICollection<BillDetail> BillDetails { get; set; }
    }
}
