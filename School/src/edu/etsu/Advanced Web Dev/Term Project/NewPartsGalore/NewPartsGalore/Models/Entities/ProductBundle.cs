using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace NewPartsGalore.Models.Entities
{
    public class ProductBundle
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Bundle Id")]
        public int BundleId { get; set; }
        [DisplayName("Product Id")]
        public int ProductId { get; set; }
        public Product? Product { get; set; }
        public Bundle? Bundle { get; set; }
    }
}
