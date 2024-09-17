
using System.ComponentModel.DataAnnotations;


namespace ServiceContracts.Dto
{
    public class ForgotPasswordViewModel
    {
        [Required(ErrorMessage = "Email Can't be blank")]
        [EmailAddress(ErrorMessage = "Email should be in a proper email address formate")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Password Can't be blank")]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 8)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,}$", ErrorMessage = "Password must contain at least 1 uppercase letter, 1 lowercase letter, and 1 digit.")]
        public string? NewPassword { get; set; }
        [DataType(DataType.Password)]
        public string? ConfirmPassword {  get; set; }


    }
}
