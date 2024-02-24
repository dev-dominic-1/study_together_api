namespace study_together_api.Entities
{
    public class Post 
    {
        public int Id { get; set; }

        public required string Title { get; set; }

        public string? Body { get; set; } = string.Empty;
    }
}