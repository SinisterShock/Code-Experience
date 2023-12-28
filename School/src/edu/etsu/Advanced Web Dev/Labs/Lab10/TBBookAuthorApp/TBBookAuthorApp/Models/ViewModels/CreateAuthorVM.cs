using System.ComponentModel.DataAnnotations;
using TBBookAuthorApp.Models.Entities;
namespace TBBookAuthorApp.Models.ViewModels
{
    public class CreateAuthorVM
    {
        [Display (Name ="First Name")]
        public string? FirstName { get; set; }

        [Display (Name ="Last Name")]
        public string? LastName { get; set;}
        public int? bookId { get; set; }

        public Author GetPersonInstance()
        {
            return new Author
            {
                Id = 0,
                FirstName = this.FirstName,
                LastName = this.LastName

            };
        }
    }
}
