using Microsoft.AspNetCore.Mvc;

namespace CatBaBooking.Controllers.HomePage;
[Route("restaurant-detail")]
public class restaurantDetailController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View("~/Views/Home/RestaurantDetail.cshtml");
    }
}