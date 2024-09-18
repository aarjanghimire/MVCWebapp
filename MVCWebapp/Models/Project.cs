namespace MVCWebapp.Models
{
    public class Project
    {
        public required int ProjectId { get; set; }
        public required string ProjectName { get; set; }
        public string? Description { get; set; }
        public required DateTime ProjectDate { get; set; }
        public required bool IsDeleted { get; set; }
        public required int UserId { get; set; }
    }
}
