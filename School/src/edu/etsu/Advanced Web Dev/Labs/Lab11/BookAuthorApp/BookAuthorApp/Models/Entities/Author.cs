using System.ComponentModel.DataAnnotations;

namespace BookAuthorApp.Models.Entities
{
	public class Author
	{
		public int Id { get; set; }
		[StringLength(128)]
		public string? FirstName { get; set; }
		[Required]
		[StringLength(128)]
		public string? LastName { get; set; }
		public ICollection<BookAuthor> BookAuthors { get; set; }
    }
}
