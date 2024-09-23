using System.ComponentModel.DataAnnotations;

namespace E_Learning.Models
{
    public class User
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        [MinLength(3, ErrorMessage = "First name must be at least 3 characters")]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "The first name must contain only alphabetic characters.")]
        public string FName { get; set; }
        [MinLength(3,ErrorMessage ="First name must be at least 3 characters")]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "The last name must contain only alphabetic characters.")]
        public  string LName { get; set; }
        [DataType(DataType.EmailAddress)]
        public  string Email { get; set; }
        public string? Addres { get; set; }
        public byte[]? Image { get; set; }
        public DateTime DateJoined { get; set; }
        public DateTime LastLogin { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string? PhoneNumber { get; set; }
        public string? ConfirmEmailCode { get; set; }
        public string? ResetPasswordCode { get; set; }
        public Enrollment? Enrollment { get; set; }
        public Earning? Earning { get; set; }
    }
}
