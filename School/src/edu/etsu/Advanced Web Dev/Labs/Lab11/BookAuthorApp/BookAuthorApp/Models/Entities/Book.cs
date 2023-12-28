using System.ComponentModel.DataAnnotations;

namespace BookAuthorApp.Models.Entities
{
	public class Book
	{
		
		public int Id { get; set; }
        [Required]
        [StringLength(256)]
        public string? Title { get; set; }
		public int PublicationYear { get; set; }

		public ICollection<BookAuthor>? BookAuthors { get; set; }
		
    }
}
