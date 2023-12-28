using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using TBBookAuthorApp.Models.Entities;

namespace TBBookAuthorApp.Models.ViewModels
{
    public class BookDetailsVM
    {
        public int Id { get; set; }
        public string Title { get; set; } = String.Empty;
        [DisplayName("Publication Year")]
        public int PublicationYear { get; set; }
        [Display(Name ="Number of Authors")]
        public int NumberOfAuthors { get; set; }
        public ICollection<Author> Authors { get; set; } = new List<Author>();
    }
}
