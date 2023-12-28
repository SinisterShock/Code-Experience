using System.ComponentModel;

namespace NewPartsGalore.Models.Entities
{
    public class User
    {
        public int Id { get; set; }
        [DisplayName("First Name")]
        public string FirstName { get; set; } = String.Empty;
        [DisplayName("Last Name")]
        public string LastName { get; set; } = String.Empty;
        public string Title { get; set; } = String.Empty;
        public string Email { get; set; } = String.Empty;
    }
}
