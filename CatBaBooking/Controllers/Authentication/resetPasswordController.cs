using Microsoft.AspNetCore.Mvc;

namespace CatBaBooking.Controllers.Authentication;
[Route("reset-password")]
public class resetPasswordController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View("~/Views/Authentication/ResetPassword.cshtml");
    }
}