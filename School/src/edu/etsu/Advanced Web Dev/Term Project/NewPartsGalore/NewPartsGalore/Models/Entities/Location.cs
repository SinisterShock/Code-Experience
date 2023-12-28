using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace NewPartsGalore.Models.Entities
{
    public class Location
    {
        /// <summary>
        /// These are the properties that a location contains
        /// </summary>
        [Key]
        public int Id { get; set; }
        [StringLength(120)]
        public string Name { get; set; } = String.Empty;
        [StringLength(120)]
        [DisplayName("Store Type")]
        public string StoreType { get; set; } = String.Empty;
        public string Address { get; set; } = String.Empty;
        public string City { get; set; } = String.Empty;
        [StringLength(2)]
        public string State { get; set; } = String.Empty;
        public string Zip { get; set; } = String.Empty;

        // A Store/Location has an inventory
        public ICollection<Inventory> LocationInventories { get; set; } = new List<Inventory>();

    }
}
