using System.ComponentModel.DataAnnotations;

namespace TBBookAuthorApp.Models.Entities
{
    public class Author
    {
        public int Id { get; set; }
        [StringLength(128)]
        public string? FirstName { get; set; }
        [StringLength(128)]
        public string LastName { get; set; } = String.Empty;
        public int BookId { get; set; }
        public Book? Book { get; set; }
    }
}
