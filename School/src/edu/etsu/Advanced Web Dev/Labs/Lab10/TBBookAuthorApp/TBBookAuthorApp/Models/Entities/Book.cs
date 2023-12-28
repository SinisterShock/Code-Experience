using System.ComponentModel.DataAnnotations;

namespace TBBookAuthorApp.Models.Entities
{
    public class Book
    {
        public int Id { get; set; }
        [StringLength(256)]
        public string Title { get; set; } = String.Empty;
        public int PublicationYear { get; set; }

        public ICollection<Author> Authors { get; set; } = new List<Author>();
    }
}
