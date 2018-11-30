using Microsoft.AspNetCore.Mvc;

namespace aspnet_html5_validation.Controllers
{
  public class EnquiryController : Controller
  {
    public IActionResult Index()
    {
      return View(new EnquiryViewModel());
    }

    [HttpPost]
    public IActionResult Enquiry(EnquiryViewModel enquiryViewModel)
    {
      return RedirectToAction(nameof(Index));
    }
    
  }
  
}