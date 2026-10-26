using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MVC_MovieArchive.Models;

namespace MVC_MovieArchive.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        using var context = new MovieArchiveDbContext();
        var movies = context.Movies.ToList();

        return View(movies);    }

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
