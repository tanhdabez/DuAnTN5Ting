namespace View.Dto
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
        public string Brand { get; set; }
        public string NhaSanXuat { get; set; }
        public string TenVatLieu { get; set; }
        public string IdLoaiSanPham { get; set; }
        public string IdBrand { get; set; }
        public string IdNhaSanXuat { get; set; }
        public string IdVatLieu { get; set; }
        public List<string> HinhAnh { get; set; }
    }

}
