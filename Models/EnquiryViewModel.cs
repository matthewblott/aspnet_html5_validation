using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace aspnet_html5_validation
{
  public class EnquiryViewModel
  {
    [MinLength(3)]
    [MaxLength(10, ErrorMessage = "{1} max characters")]
    [Required]
    [Editable(true)]
    [Display(Prompt = nameof(Name))]
    [DisplayName(nameof(Name))]
    [StringLengthAttribute(20, MinimumLength = 3)]
    public string Name { get; set; }
    
    [MaxLength(20)]
    [Required]
    [EmailAddress]
    [Display(Prompt = "Email")]
    [StringLengthAttribute(20, MinimumLength = 3)]
    public string Email { get; set; }

    [Required]
    [Display(Prompt = "Subject(s)")]
    //public IEnumerable<SelectListItem> Subjects { get; set; }
    public MultiSelectList Subjects { get; set; }
    
    [Required]
    [Display(Prompt = "Message")]
    public string Message { get; set; }
    
  }
  
}