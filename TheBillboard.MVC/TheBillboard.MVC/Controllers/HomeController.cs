namespace TheBillboard.MVC.Controllers;

using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Models;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger) => _logger = logger;

    public IActionResult Index()
    {
        _logger.LogInformation("Home.Index was called");
        return View();
    }

    public IActionResult About()
    {
        _logger.LogInformation("Home.About was called");
        return View();
    }

    public IActionResult GoToMessages()
    {
        _logger.LogInformation("Redirect to Message.Index");
        return RedirectToAction("Index", "Message");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error() => View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
}