using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using be.Models;
using be.Interfaces;

namespace be.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IScraper _scraper;

    public HomeController(
        ILogger<HomeController> logger,
        IScraper scraper
        )
    {
        _logger = logger;
        _scraper = scraper;
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
        string url = "https://hr.asia/awards/malaysia-2023/";
        string query = "div.custom-winner .feature_box .feature_box_wrapper";

        ICollection<Company> companies = _scraper.GetItems<Company>(url, query, element =>
        {
            string name = element.InnerText.Trim();
            return new Company { Name = name };
        });

        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
