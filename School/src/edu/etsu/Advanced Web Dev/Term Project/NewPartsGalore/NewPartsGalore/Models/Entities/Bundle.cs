using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace NewPartsGalore.Models.Entities
{
    public class Bundle
    {
        /// <summary>
        /// These are the properties of a Bundle
        /// </summary>
        [Key]
        public int Id { get; set; }
        // This is used so there can be multiple of the same bundle
        [DisplayName("Serial Number")]
        public int SerialNumber { get; set; }
        public string Name { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;
        public double Price { get; set; }
        // M:M connection to Bundles
        public ICollection<ProductBundle>? ProductBundles { get; set; }

    }
}
