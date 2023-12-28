namespace NewPartsUsers.Models.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = String.Empty;
        public string LastName { get; set; } = String.Empty;
        public string Title { get; set; } = String.Empty;
        public string Email { get; set; } = String.Empty;
    }
}
