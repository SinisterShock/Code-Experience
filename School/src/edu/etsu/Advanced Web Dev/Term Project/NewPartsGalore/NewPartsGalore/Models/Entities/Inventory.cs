using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace NewPartsGalore.Models.Entities
{
    public class Inventory
    {
        /// <summary>
        /// These are the properties of an inventory for a location
        /// **AN INVENTORY CAN NOT EXIST WITHOUT A LOCATION**
        /// </summary>
        [Key]
        public int Id { get; set; }
        [DisplayName("Location Code")]
        public int LocationId { get; set; }
        public Location? Location { get; set; }

        // An inventory contains a collection of products an bundles
        public ICollection<Product>? Products { get; set; } = new List<Product>();

    }
}
