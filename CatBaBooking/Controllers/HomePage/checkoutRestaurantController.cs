using Microsoft.AspNetCore.Mvc;

namespace CatBaBooking.Controllers.HomePage;
[Route("checkout-restaurant")]
public class checkoutRestaurantController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View("~/Views/Home/CheckoutRestaurant.cshtml");
    }
}