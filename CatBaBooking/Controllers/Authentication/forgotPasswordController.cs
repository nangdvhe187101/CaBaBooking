using Microsoft.AspNetCore.Mvc;

namespace CatBaBooking.Controllers.Authentication;
[Route("forgot-password")]
public class forgotPasswordController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View("~/Views/Authentication/ForgotPassword.cshtml");
    }
}