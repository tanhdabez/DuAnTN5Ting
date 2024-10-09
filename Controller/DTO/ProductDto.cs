using DemoBanQuanAo.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Controller.DTO
{
    public class ProductDto
    {
        public string Id { get; set; }
        public string MaSanPham { get; set; }
        public string TenSanPham { get; set; }
        public decimal GiaSanPham { get; set; }
        public int NamSanXuat { get; set; }
        public string MoTa { get; set; }
        public string LoaiSanPham { get; set; }
        public string IdLoaiSanPham { get; set; }
        public string Brand { get; set; }
        public string IdBrand { get; set; }
        public string NhaSanXuat { get; set; }
        public string IdNhaSanXuat { get; set; }
        public string TenVatLieu { get; set; }
        public string IdVatLieu { get; set; }
        public List<int> SoLuong { get; set; }
        public List<string> HinhAnh { get; set; }
        public List<string> ColorId { get; set; }
        public List<string> SizeId { get; set; }
    }
    public class ProductDetailDto
    {
        public string Id { get; set; }
        public string ProductId { get; set; }
        public int SoLuong { get; set; }
        public DateTime NgayTao { get; set; }
        public DateTime NgayCapNhat { get; set; }
        public string TrangThai { get; set; }
        public List<string> ColorIds { get; set; }
        public List<string> SizeIds { get; set; }
    }
    public class ColorDto
    {
        public string Id { get; set; }
        public string Ma { get; set; }
        public string Ten { get; set; }
    }
    public class SizeDto
    {
        public string Id { get; set; }
        public string Ma { get; set; }
        public string Ten { get; set; }
    }
}
