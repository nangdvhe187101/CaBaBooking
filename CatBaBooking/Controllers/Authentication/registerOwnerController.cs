using Microsoft.AspNetCore.Mvc;

namespace CatBaBooking.Controllers.Authentication;

[Route("register-owner")]
public class registerOwnerController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View("~/Views/Authentication/RegisterOwner.cshtml");
    }
}