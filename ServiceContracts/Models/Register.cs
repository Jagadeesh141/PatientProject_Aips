
using System.ComponentModel.DataAnnotations;


namespace ServiceContracts.Dto
{
    public class Register
    {
        [Required(ErrorMessage ="Name Can't be blank")]
        public string? PersonName { get; set; }
        [Required(ErrorMessage = "Email Can't be blank")]
        [EmailAddress(ErrorMessage ="Email should be in a proper email address formate")]

        public string? Email {  get; set; }
        [Required(ErrorMessage = "Phone Number Can't be blank")]
        [RegularExpression("^[0-9]*$",ErrorMessage ="Phone numder should contain numbers only")]
        [DataType(DataType.PhoneNumber)]
        public string? Phone { get; set; }
        [Required(ErrorMessage = "Password Can't be blank")]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters long")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
        [Required(ErrorMessage = "Confirm PassWord  Can't be blank")]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage ="Password and Confirm password do not matched ")]
        public string? ConfirmPassword { get; set; }
        

    }
}
