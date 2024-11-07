using Controller.Models;
using System.ComponentModel.DataAnnotations;

namespace DemoBanQuanAo.Models
{
    public class Product
    {
        public string Id { get; set; }
        public string Ma { get; set; }

        [Required]
        [MaxLength(100)]
        public string Ten { get; set; }

        public decimal Gia { get; set; }
        public int NamSX { get; set; }
        public string MoTa { get; set; }

        public string? ProductTypeId { get; set; }
        public string? BrandId { get; set; }
        public string? ManufacturerId { get; set; }
        public string MaterialId { get; set; }
        public Material Material { get; set; }
        public ProductType? ProductType { get; set; }
        public Brand? Brand { get; set; }
        public Manufacturer? Manufacturer { get; set; }

        public ICollection<ProductDetail> ProductDetails { get; set; }
        public ICollection<ProductImage>? ProductImages { get; set; }
    }

}
