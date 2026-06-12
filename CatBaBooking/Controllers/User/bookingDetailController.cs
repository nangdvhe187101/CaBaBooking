using Microsoft.AspNetCore.Mvc;

namespace CatBaBooking.Controllers.User;
[Route("booking-detail")]
public class bookingDetailController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View("~/Views/User/BookingDetail.cshtml");
    }
}