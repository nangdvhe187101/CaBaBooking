using Microsoft.AspNetCore.Mvc;

namespace CatBaBooking.Controllers.HomePage;
[Route("homestay-page")]
public class homestayController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View("~/Views/Home/Homestay.cshtml");
    }
}