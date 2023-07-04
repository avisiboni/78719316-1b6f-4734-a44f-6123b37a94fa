using System.ComponentModel.DataAnnotations;

namespace WebApplication4.Models
{
    public class UserDto
    {
        [Required]
        public required string Username { get; set; }
        [Required]
        [RegularExpression(@"^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%]).{8,32}$", ErrorMessage = @"Error. Password must have one capital, one special character and one numerical character. It can not start with a special character or a digit.")]
        public required string Password { get; set; }
    }
}
