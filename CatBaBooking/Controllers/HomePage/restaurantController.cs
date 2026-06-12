using Microsoft.AspNetCore.Mvc;

namespace CatBaBooking.Controllers.HomePage;
[Route("restaurant-page")]
public class restaurantController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View("~/Views/Home/Restaurant.cshtml");
    }
}