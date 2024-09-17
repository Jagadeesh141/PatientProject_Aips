
using System.ComponentModel.DataAnnotations;


namespace ServiceContracts.Dto
{
    public class Login
    {
        [Required(ErrorMessage ="Email can't be blank")]
        [EmailAddress(ErrorMessage ="Email should be in the proper email address format")]
        public String? Email { get; set; }
        [Required(ErrorMessage = "Password can't be blank")]
        [DataType(DataType.Password)]
        public String? Password { get; set; }
    }
}
