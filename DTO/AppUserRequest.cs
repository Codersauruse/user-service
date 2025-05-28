using System.ComponentModel.DataAnnotations;

namespace user_service.DTO;

public class AppUserRequest
{
    [Required(ErrorMessage = "Username is required")]
    [StringLength(20, MinimumLength = 3, ErrorMessage = "Username must be between 3 and 20 characters")] 
    public  string name { get; set; }
    
    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Enter a valid email address")]
    public string email { get; set; }
    [Required(ErrorMessage = "Password is required")]
    [StringLength(20, MinimumLength = 3, ErrorMessage = "Password must be between 3 and 20 characters")]
    public  string password { get; set; }
}