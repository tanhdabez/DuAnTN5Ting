namespace Controller.DTO
{
    public class CustomerDto
    {
        public string Id { get; set; }
        public string Ma { get; set; }
        public string Ten { get; set; }
        public string SDT { get; set; }
        public string Email { get; set; }
        public string Anh { get; set; }
        public string GioiTinh { get; set; }
        public string MatKhau { get; set; }
        public string TrangThai { get; set; }
        public DateTime NgaySinh { get; set; }
        public List<AddressDto> Address { get; set; }
    }
}
