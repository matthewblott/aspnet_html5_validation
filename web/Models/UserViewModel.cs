using System;
using System.ComponentModel.DataAnnotations;

namespace aspnet_html5_validation
{
  public class UserViewModel
  {
    public enum GenderType
    {
      Male,
      Female,
      Other
    }
    
    [MinLength(3)]
    [MaxLength(20)]
    [Required]
    [Editable(true)]
    [Display(Prompt = "Username")]
    [StringLengthAttribute(20, MinimumLength = 3)]
    public string Username { get; set; }
    
    [MaxLength(20)]
    [Required]
    [EmailAddress]
    [Display(Prompt = "Email")]
    [StringLengthAttribute(20, MinimumLength = 3)]
    public string Email { get; set; }
    
    [Required]
    [Display(Name = "Gender")]
    public GenderType Gender { get; set; }
    
    [Required]
    [Display(Name = "Date of birth", Prompt = "2018-12-31")]
    [RegularExpression("[0-9]{4}-[0-9]{2}-[0-9]{2}")]
    [DataType(DataType.Date)]
    public DateTime DateOfBirth { get; set; }
    
    [MaxLength(20)]
    [Required]
    [DataType(DataType.Password)]
    [StringLengthAttribute(20, MinimumLength = 1)]
    [Display(Name = "Password", Prompt = "Password")]
    [RegularExpression(@"^([a-zA-Z])(?=.*\d)\w{4,9}$")]
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