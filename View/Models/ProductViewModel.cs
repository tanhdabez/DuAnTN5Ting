using System.ComponentModel.DataAnnotations;

namespace View.Models
{
    public class ProductViewModel
    {
        public string Id { get; set; }

        public string MaSanPham { get; set; }

        public string TenSanPham { get; set; }

        public decimal GiaSanPham { get; set; }

        public int? NamSanXuat { get; set; } 

        public string MoTa { get; set; }

        public string LoaiSanPham { get; set; } 

        public string Brand { get; set; } 

        public string NhaSanXuat { get; set; } 

        public string TenVatLieu { get; set; } 

        public string IdLoaiSanPham { get; set; } 

        public string IdBrand { get; set; } 

        public string IdNhaSanXuat { get; set; } 

        public string IdVatLieu { get; set; }
        public List<string> HinhAnhs { get; set; }
    }
    //public class ProductAddViewModel
    //{
    //    public string Id { get; set; }

    //    [Required(ErrorMessage = "Mã sản phẩm không được để trống.")]
    //    public string MaSanPham { get; set; }

    //    [Required(ErrorMessage = "Tên sản phẩm không được để trống.")]
    //    public string TenSanPham { get; set; }

    //    [Required(ErrorMessage = "Giá sản phẩm không được để trống.")]
    //    [Range(0, double.MaxValue, ErrorMessage = "Giá sản phẩm phải lớn hơn hoặc bằng 0.")]
    //    public decimal GiaSanPham { get; set; }

    //    public int NamSanXuat { get; set; }
    //    public string MoTa { get; set; }

    //    [Required(ErrorMessage = "Loại sản phẩm không được để trống.")]
    //    public string ProductTypeId { get; set; }

    //    [Required(ErrorMessage = "Thương hiệu không được để trống.")]
    //    public string BrandId { get; set; }

    //    [Required(ErrorMessage = "Nhà sản xuất không được để trống.")]
    //    public string ManufacturerId { get; set; }

    //    [Required(ErrorMessage = "Vật liệu không được để trống.")]
    //    public string MaterialId { get; set; }
    //}

    public class ProductAddViewModel
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

    public class MaterialViewModel
    {
        public string Id { get; set; }
        public string Ma { get; set; }
        public string Ten { get; set; }
        public string TrangThai { get; set; }
    }
    public class ManufacturerViewModel
    {
        public string Id { get; set; }
        public string Ma { get; set; }
        public string Ten { get; set; }
        public string TrangThai { get; set; }
    }
    public class BrandViewModel
    {
        public string Id { get; set; }
        public string Ma { get; set; }
        public string Ten { get; set; }
        public string TrangThai { get; set; }
    }
    public class ProductTypeViewModel
    {
        public string Id { get; set; }
        public string Ma { get; set; }
        public string Ten { get; set; }
        public string TrangThai { get; set; }
    }
    public class ColorViewModel
    {
        public string Id { get; set; }
        public string Ma { get; set; }
        public string Ten { get; set; }
    }
    public class SizeViewModel
    {
        public string Id { get; set; }
        public string Ma { get; set; }
        public string Ten { get; set; }
    }
}
