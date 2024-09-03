using MVCWebapp.Models;

namespace MVCWebapp.ViewModel
{
    public class UserAggregatedInfo
    {
        public User User { get; set; }
        public List<Skill> UserSkills { get; set; }
    }
}
