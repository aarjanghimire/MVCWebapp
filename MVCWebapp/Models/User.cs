namespace MVCWebapp.Models
{
    public class User
    {
        public int UserId { get; set; }
        public required string FullName { get; set; }
        public required string Email { get; set; }
        public required string GithubLink { get; set; }
        public required string LinkedInName { get; set; }
        public int Phone { get; set; }
        public required string Description { get; set; }
    }
}
