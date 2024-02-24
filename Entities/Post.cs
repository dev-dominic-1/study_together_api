namespace study_together_api.Entities
{
    public class Post 
    {
        public int Id { get; init; }

        public required string Title { get; set; }

        public required string Body { get; set; }
    }
}