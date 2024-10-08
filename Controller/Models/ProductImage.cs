using DemoBanQuanAo.Models;
using System.ComponentModel.DataAnnotations;

namespace Controller.Models
{
    public class ProductImage
    {
        public string Id { get; set; }

        public string ImageUrl { get; set; }

        public string ProductId { get; set; }
        public Product Product { get; set; }
    }
}
