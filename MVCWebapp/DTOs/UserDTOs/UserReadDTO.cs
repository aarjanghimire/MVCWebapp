using MVCWebapp.DTOs.UserTypeDTOs;

namespace MVCWebapp.DTOs.UserDTOs
{
    public class UserReadDTO
    {
        public required int UserId { get; set; }
        public required string FullName { get; set; }
        public required string Email { get; set; }
        public required string GithubLink { get; set; }
        public required string LinkedInName { get; set; }
        public required int Phone { get; set; }
        public required string Description { get; set; }
        public required int UserTypeId { get; set; }
        public UserTypeReadDTO? UserType { get; set; }
    }
}
