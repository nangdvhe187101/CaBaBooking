using Microsoft.AspNetCore.Mvc;

namespace CatBaBooking.Controllers.HomePage;
[Route("booking-homestay")]
public class bookingHomestayController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View("~/Views/Home/BookingHomestay.cshtml");
    }
}