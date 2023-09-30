using GenericController.Appliction.API.Enums;

namespace GenericController.Appliction.API.Models
{
    public class User : BaseModel
    {
        public required string Username { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public required bool IsActive { get; set; }
        public required UserRole Role { get; set; }
    }
}
