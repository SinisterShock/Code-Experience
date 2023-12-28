using BookAuthorApp.Models.Entities;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BookAuthorApp.Models.ViewModels
{
    public class AuthorDetailsVM
    {
        public int Id { get; set; }
        [DisplayName("First Name")]
        public string? FirstName { get; set; }
        [DisplayName("Last Name")]
        public string? LastName { get; set; }
        [DisplayName("Number of Books")]
        public int NumberOfBooks { get; set; }
        public ICollection<BookAuthor>? BookAuthors { get; set; }
        
    }
}
