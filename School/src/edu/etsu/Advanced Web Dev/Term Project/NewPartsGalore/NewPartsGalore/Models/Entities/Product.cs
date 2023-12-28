using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace NewPartsGalore.Models.Entities
{
    public class Product
    {
        /// <summary>
        /// These are the Product properties
        /// </summary>
        [Key]
        public int Id { get; set; }
        // this Id is used so there can be multiple of the same item
        [DisplayName("Serial Number")]
        public int SerialNumber { get; set; }
        public string Name { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;
        public double Price { get; set; }
        [DisplayName("Inventory Code")]
        public int InventoryId { get; set; }
        public Inventory? Inventory { get; set; }
        [DisplayName("Vendor Code")]
        public int VendorId { get; set; }
        public Vendor? Vendor { get; set; }
        // M:M connection to Bundles
        public ICollection<ProductBundle>? ProductBundles { get; set; }

    }
}
