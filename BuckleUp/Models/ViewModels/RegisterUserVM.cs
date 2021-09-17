using System.ComponentModel.DataAnnotations;

namespace BuckleUp.Models.ViewModels
{
    public class RegisterUserVM
    {
        [Required(ErrorMessage = "First Name is required")]
        public string FirstName { get; set; }
       
       [Required(ErrorMessage = "Last Name  is required")]
        public string LastName { get; set; }
       
        
        public string MiddleName { get; set; }
        
        [Required(ErrorMessage = "Email is required")]
        [RegularExpression("^[a-zA-Z0-9_.-]+@[a-zA-Z0-9-]+.[a-zA-Z0-9-.]+$", ErrorMessage = "Must be a valid email")]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "Password is required")]
        [StringLength(255, ErrorMessage = "Must be between 5 and 255 characters", MinimumLength = 5)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        
        [Required(ErrorMessage = "Confirm Password is required")]
        [StringLength(255, ErrorMessage = "Must be between 5 and 255 characters", MinimumLength = 5)]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
        public string UserType {get; set;}
    }
}