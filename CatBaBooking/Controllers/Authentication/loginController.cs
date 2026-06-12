using Microsoft.AspNetCore.Mvc;

namespace CatBaBooking.Controllers.Authentication;

[Route("login")]
public class loginController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View("~/Views/Authentication/Login.cshtml");
    }
}