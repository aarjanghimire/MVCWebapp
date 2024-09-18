namespace MVCWebapp.Models
{
    public class Skill
    {
        public required int SkillId { get; set; }
        public required string SkillName { get; set; }
        public required int UserId { get; set; }
        public required bool IsDeleted { get; set; }
    }
}
