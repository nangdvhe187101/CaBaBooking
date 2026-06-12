using Microsoft.AspNetCore.Mvc;

namespace CatBaBooking.Controllers.HomePage;
[Route("homestay-detail")]
public class homestayDetailController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View("~/Views/Home/homestayDetail.cshtml");
    }
}