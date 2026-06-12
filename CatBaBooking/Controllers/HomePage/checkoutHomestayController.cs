using Microsoft.AspNetCore.Mvc;

namespace CatBaBooking.Controllers.HomePage;
[Route("checkout-homestay")]
public class checkoutHomestayController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View("~/Views/Home/CheckoutHomestay.cshtml");
    }
}