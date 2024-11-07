using Controller.Models;
using System.ComponentModel.DataAnnotations;

namespace DemoBanQuanAo.Models
{
    public class Customer
    {
        public string Id { get; set; }
        public string Ma { get; set; }

        [Required]
        [MaxLength(50)]
        public string Ten { get; set; }
        public string Anh { get; set; }
        public string GioiTinh { get; set; }
        public DateTime NgaySinh { get; set; }
        public string Email { get; set; }
        public string SDT { get; set; }
        public string MatKhau { get; set; }
        public DateTime NgayTao { get; set; }
        public DateTime NgayCapNhat { get; set; }
        public string TrangThai { get; set; }

        public virtual Cart? Carts { get; set; }
        public virtual ICollection<Bill>? Bills { get; set; }

        public virtual List<Address> Addresses { get; set; }
    }
}
