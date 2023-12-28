using BookAuthorApp.Models.Entities;
using System.Collections.Generic;
using System.ComponentModel;

namespace BookAuthorApp.Models.ViewModels
{
    public class EditAuthorVM
    {
        public Book? Book { get; set; }
        public int Id { get; set; }
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        public int BookId { get; set; }
        public Author GetAuthorInstance()
        {
            return new Author
            {
                Id = this.Id,
                //Book = this.Book,
                FirstName = this.FirstName,
                LastName = this.LastName
            };
        }
    }
}
