namespace study_together_api.Entities
{
    public class User {

        public int Id { get; set; }

        public required string Name { get; set; }

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public virtual ICollection<Post> Posts { get; set; } = [];
    }
}