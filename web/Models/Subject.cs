using System.ComponentModel.DataAnnotations;

namespace aspnet_html5_validation
{
  public class Subject
  {
    public int Id { get; set; }
    
    [Display(Name = "A - Z")]
    public string Name { get; set; }
  }
}