using Microsoft.AspNetCore.Mvc;

namespace CatBaBooking.Controllers.HomePage;
[Route("home-page")]
public class homePageController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View("~/Views/Home/HomePage.cshtml");
    }
}