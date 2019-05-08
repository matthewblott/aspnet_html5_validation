using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace aspnet_html5_validation.controllers
{
  public class EnquiryController : Controller
  {
    private static IEnumerable<Subject> GetSubjectList()
    {
      return new List<Subject>
      {
        new Subject
        {
          Id = 1,
          Name = "A",
        },
        new Subject
        {
          Id = 2,
          Name = "B",
        },
        new Subject
        {
          Id = 3,
          Name = "C",
        },
        new Subject
        {
          Id = 4,
          Name = "D",
        },
        new Subject
        {
          Id = 5,
          Name = "E",
        },
      };

    }

    public IActionResult Index()
    {
      var model = new EnquiryViewModel
      {
        Subjects = new MultiSelectList(GetSubjectList(), nameof(Subject.Id), nameof(Subject.Name))
      };
      
      return View(model);
    }

    public IActionResult Subjects()
    {
      return View(GetSubjectList());
    }
    
    [HttpPost]
    public IActionResult Enquiry(EnquiryViewModel enquiryViewModel)
    {
      return RedirectToAction(nameof(Index));
    }
    
  }
  
}