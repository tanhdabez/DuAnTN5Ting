using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoBanQuanAo.Models
{
    public class Size
    {
        public string Id { get; set; }
        public string Ma { get; set; }
        [Required]
        [MaxLength(50)]
        public string Ten { get; set; }

        public ICollection<ProductDetailSize> ProductDetailSizes { get; set; }
    }
}
