namespace DemoBanQuanAo.Models
{
    public class Color
    {
        public string Id { get; set; }
        public string Ma { get; set; }

        public string Ten { get; set; }

        public ICollection<ProductDetailColor> ProductDetailColors { get; set; }
    }
}
