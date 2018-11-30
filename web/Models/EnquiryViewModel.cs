using System;
using System.ComponentModel.DataAnnotations;
namespace aspnet_html5_validation
{
  public class EnquiryViewModel
  {
    [Required]
    [MaxLength(10, ErrorMessage = "{1} max characters")]
    [Display(Prompt = "Name")]
    public string Name { get; set; }
    
    //[Required]
    [Display(Prompt = "Email")]
    public string Email { get; set; }
    
    [Required]
    [Display(Prompt = "Message")]
    public string Message { get; set; }
    
  }
  
}