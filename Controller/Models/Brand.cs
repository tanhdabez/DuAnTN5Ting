using System.ComponentModel.DataAnnotations;

namespace DemoBanQuanAo.Models
{
    public class Brand
    {
        public string Id { get; set; }
        public string Ma { get; set; }
        [Required]
        [MaxLength(50)]
        public string Ten { get; set; }
        public DateTime NgayTao { get; set; }
        public DateTime NgayCapNhat { get; set; }
        public string TrangThai { get; set; }

        public ICollection<Product>? Products { get; set; }
    }
}
