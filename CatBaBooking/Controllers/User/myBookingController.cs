using Microsoft.AspNetCore.Mvc;

namespace CatBaBooking.Controllers.User;
[Route("my-booking")]
public class myBookingController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View("~/Views/User/MyBooking.cshtml");
    }
}