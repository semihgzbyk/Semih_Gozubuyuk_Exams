using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
namespace event_manager_MVC.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
    public IActionResult Consultants()
    {
        return View();
    }
    public IActionResult Reservation()
    {
        return View();
    }

}
