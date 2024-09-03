namespace MVCWebapp.Models
{
    public class Skill
    {
        public int SkillId { get; set; }
        public required string SkillName { get; set; }
        public int UserId { get; set;}
        public User User { get; set;}
    }
}
