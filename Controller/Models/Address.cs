using DemoBanQuanAo.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Controller.Models
{
    public class Address
    {
        public string Id { get; set; }
        [ForeignKey("Customer")]
        public string? CustomerId { get; set; }
        public string TenPhuongXa { get; set; }
        public string TenQuanHuyen { get; set; }
        public string TenTinh { get; set; }
        public bool IsPrimary { get; set; }

        public virtual Customer Customers { get; set; }
    }
}
