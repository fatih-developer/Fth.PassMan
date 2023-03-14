using System.ComponentModel.DataAnnotations;

namespace PassMan.UI.Models
{
    public class RegisterViewModel
    {
        [Required]
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        //[Required]
        //[DataType(DataType.Password)]
        //public string ConfirmPassword { get; set; }
        public string? Email { get; set; }
    }
}
