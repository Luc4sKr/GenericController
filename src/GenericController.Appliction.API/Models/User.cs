using GenericController.Appliction.API.Enums;
using System.ComponentModel.DataAnnotations;

namespace GenericController.Appliction.API.Models
{
    public class User : BaseModel
    {
        [Required]
        public required string Username { get; set; }
        
        [Required]
        public required string Email { get; set; }
        
        [Required]
        public required string Password { get; set; }

        [Required]
        public required bool IsActive { get; set; }

        [Required]
        public required UserRole Role { get; set; }
    }
}
