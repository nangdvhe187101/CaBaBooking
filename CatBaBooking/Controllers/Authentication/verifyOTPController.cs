using Microsoft.AspNetCore.Mvc;

namespace CatBaBooking.Controllers.Authentication;
[Route("verify-otp")]
public class verifyOTPController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View("~/Views/Authentication/VerifyOTP.cshtml");
    }
}