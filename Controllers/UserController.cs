using System;
using Microsoft.AspNetCore.Mvc;

namespace aspnet_html5_validation.Controllers
{
  public class UserController : Controller
  {
    public IActionResult Index()
    {
      var userViewModel = new UserViewModel();
      
//      userViewModel.DateOfBirth = DateTime.Today;
      
      return View(userViewModel);
      
    }

    [HttpPost]
    public IActionResult Create()
    {
      return RedirectToAction(nameof(Index));

    }
    
  }
  
}