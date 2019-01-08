using System.ComponentModel.DataAnnotations;

namespace aspnet_html5_validation
{
  public class UserViewModel
  {
    [MinLength(3)]
    [MaxLength(20)]
    [Required]
    [Editable(true)]
    [Display(Prompt = "Username")]
    [StringLengthAttribute(20, MinimumLength = 3)]
    public string Username { get; set; }
    
//    public string FirstName { get; set; }
//    public string LastName { get; set; }
    
    [MaxLength(20)]
    [Required]
    [EmailAddress]
    [Display(Prompt = "Email")]
    [StringLengthAttribute(20, MinimumLength = 3)]
    public string Email { get; set; }
    
    [MaxLength(20)]
    [Required]
    [DataType(DataType.Password)]
    [StringLengthAttribute(20, MinimumLength = 1)]
    [Display(Name = "Password", Prompt = "Password")]
    public string Password { get; set; }  
    
    [MaxLength(20)]
    [Required]
    [StringLengthAttribute(20, MinimumLength = 1)]
    [DataType(DataType.Password)]
    [Compare(nameof(Password), ErrorMessage = "The passwords do not match")]
    [Display(Name = "Password Compare", Prompt = "Password Compare")]
    public string PasswordCompare { get; set; }
    
  }
  
}