using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoBanQuanAo.Models
{
    public class Bill
    {
        public string Id { get; set; }

        [ForeignKey("Customer")]
        public string CustomerId { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }

        [ForeignKey("Voucher")]
        public string? VoucherId { get; set; }

        public decimal TienVanChuyen { get; set; }
        public decimal TienChuyenKhoan { get; set; }
        public DateTime? TietMat { get; set; }
        public string MaGiaoDichCK { get; set; }
        public decimal SoTienMat { get; set; }
        public string PhuongThucThanhToan { get; set; }
        public decimal ThanhTien { get; set; }
        public string TrangThai { get; set; }

        public Customer Customer { get; set; }
        public User User { get; set; }
        public Voucher Voucher { get; set; }
        public ICollection<BillDetail> BillDetails { get; set; }
    }
}
