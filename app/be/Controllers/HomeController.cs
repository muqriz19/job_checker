using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using be.Models;
using be.Interfaces;

namespace be.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ICompanies _companies;


    public HomeController(
        ILogger<HomeController> logger,
        ICompanies companies
        )
    {
        _logger = logger;
        _companies = companies;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult JobChecker()
    {
        ICollection<TheCompany> listOfCompanies = _companies.GetTheCompanies();
        return View(listOfCompanies);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
