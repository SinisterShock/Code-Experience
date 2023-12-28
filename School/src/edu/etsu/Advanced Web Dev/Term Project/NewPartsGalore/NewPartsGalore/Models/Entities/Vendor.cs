using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace NewPartsGalore.Models.Entities
{
    public class Vendor
    {
        /// <summary>
        /// These are the properties for a vendor
        /// </summary>
        [Key]
        public int Id { get; set; }
        [StringLength(120)]
        public string Name { get; set; } = String.Empty;
        [StringLength(120)]
        public string Representative { get; set; } = String.Empty;
        [DisplayName("Phone Number")]
        public string PhoneNumber { get; set; } = String.Empty;
        public string Address { get; set; } = String.Empty;
        public string City { get; set; } = String.Empty;
        [StringLength(2)]
        public string State { get; set; } = String.Empty;
        public string Zip { get; set; } = String.Empty;

        // A vendor contains a collection of products

        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
