using System.ComponentModel.DataAnnotations;

namespace E_Learning.Areas.Authentication.Models
{
    public class RegisterRequest
    {
        [MinLength(3, ErrorMessage = "First name must be at least 3 characters")]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "The first name must contain only alphabetic characters.")]
        public string FName { get; set; }
        [MinLength(3, ErrorMessage = "First name must be at least 3 characters")]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "The last name must contain only alphabetic characters.")]
        public string LName { get; set; }
        public string UserName { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
       
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password is required.")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 8)]
        [RegularExpression(@"^(?=.*[a-zA-Z])(?=.*\d)(?=.*[@$!%*?&#])[A-Za-z\d@$!%*?&#]{8,}$",
        ErrorMessage = "Password must be at least 8 characters, contain one Uppercase, one lowercase, one number, and one special character.")]

        public string Password { get; set; }
        [Required(ErrorMessage ="You must choose a role")]
        public string RegisteredAs { get; set; }

    }
}
