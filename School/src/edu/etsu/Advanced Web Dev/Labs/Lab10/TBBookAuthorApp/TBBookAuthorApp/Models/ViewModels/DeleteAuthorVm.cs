using TBBookAuthorApp.Models.Entities;

namespace TBBookAuthorApp.Models.ViewModels
{
    public class DeleteAuthorVm
    {
        public Book? BookDelete { get; set; }
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set;} = string.Empty;
        

    }
}
