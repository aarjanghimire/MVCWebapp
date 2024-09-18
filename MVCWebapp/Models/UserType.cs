namespace MVCWebapp.Models
{
    public class UserType
    {
        public int UserTypeId { get; set; }
        public required string UserTypeName { get; set; }
        public required bool IsDeleted { get; set; }
    }
}
