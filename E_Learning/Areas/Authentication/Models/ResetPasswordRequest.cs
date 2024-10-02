using System.ComponentModel.DataAnnotations;

namespace E_Learning.Areas.Authentication.Models
{
    public class ResetPasswordRequest
    {
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }
        public int? Code { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password is required.")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 8)]
        [RegularExpression(@"^(?=.*[a-zA-Z])(?=.*\d)(?=.*[@$!%*?&#])[A-Za-z\d@$!%*?&#]{8,}$",
       ErrorMessage = "Password must be at least 8 characters, contain one Uppercase, one lowercase, one number, and one special character.")]
        public string? Password { get; set; }
        [Compare("Password")]
        public string? ConfirmPassword { get; set; }
    }
}
