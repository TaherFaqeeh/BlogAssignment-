using System.ComponentModel.DataAnnotations;

namespace BlogIt.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required(AllowEmptyStrings =false, ErrorMessage ="First Name Is Required")]
        [Display(Name = "First Name")]
        [StringLength(50, MinimumLength = 3)]
        public string FirstName { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Last Name Is Required")]
        [Display(Name = "Last Name")]
        [StringLength(50, MinimumLength = 3)]
        public string LastName { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Email Is Required")]
        [Display(Name = "Email Address")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}")]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Password")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,15}$")]
        public string Password { get; set; }
        [Required]
        [Display(Name = "Confirm Password")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,15}$")]
        public string ConfirmPassword { get; set; }
    }

}
