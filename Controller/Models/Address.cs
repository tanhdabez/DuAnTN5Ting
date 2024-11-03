using DemoBanQuanAo.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Controller.Models
{
    public class Address
    {
        public string Id { get; set; }
        [ForeignKey("Customer")]
        public string CustomerId { get; set; }
        public string DiaChiChiTiet { get; set; }
        public string HoVaTen { get; set; }
        public int SDT { get; set; }
        public string MaPhuongXa { get; set; }
        public string MaQuanHuyen { get; set; }
        public string MaTinh { get; set; }
        public string TenPhuongXa { get; set; }
        public string TenQuanHuyen { get; set; }
        public string TenTinh { get; set; }

        public Customer Customers { get; set; }
    }
}
