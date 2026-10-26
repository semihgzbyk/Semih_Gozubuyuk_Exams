using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MVC_Library.Models;

namespace MVC_Library.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        using var context = new LibraryDbContext();
        var books = context.Books.ToList();

        return View(books);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
