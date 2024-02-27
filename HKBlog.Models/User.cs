
namespace HKBlog.Models
{
    using System.ComponentModel.DataAnnotations;
    public class User
    {
        public string Id { get; set; } = "";
        [Required]
        [EmailAddress]
        public string Email { get; set; } = "";
        [Required]
        public string Mobile { get; set; } = "";
        [Required]
        public string Password { get; set; } = "";
        [Required]
        [Compare("Password", ErrorMessage = "Password fields do not match, ensure both fields are the same.")]
        public string Password2 { get; set; } = string.Empty;
        public string Filepath { get; set; } = string.Empty;
        [Required]
        public string Username { get; set; } = "";
        public bool IsAdmin { get; set; }
        public bool IsEditAccount { get; set; } = false;
        public bool IsVendor{ get; set; }
        [Required]
        public string Center { get; set; } = "None";
        //[Required]
        public int OTP { get; set; }
    }
    /*
     *Regular expression for creating complex password.
     *I choose to keep it simple for my users.
             [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{8,}$",
            ErrorMessage = "Password must have at least 8 characters, including a letter, number, and special character.")]
     */
}