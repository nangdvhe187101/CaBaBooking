using CatBaBooking.Service.Interface.Auth;
using Microsoft.AspNetCore.Mvc;

namespace CatBaBooking.Controllers.Authentication;
[Route("forgot-password")]
public class forgotPasswordController : Controller
{
    private readonly IForgotPasswordService forgotPasswordService;

    public forgotPasswordController(IForgotPasswordService forgotPasswordService)
    {
        this.forgotPasswordService = forgotPasswordService;
    }
    // GET
    public IActionResult Index()
    {
        return View("~/Views/Authentication/ForgotPassword.cshtml");
    }

    [HttpPost]
    public async Task<IActionResult> SendOtp(string email)
    {
        if (string.IsNullOrEmpty(email))
        {
            ViewBag.Error = "Không được để trống";
            return View("~/Views/Authentication/ForgotPassword.cshtml");
        }

        string otp = await forgotPasswordService.SendOTPAsync(email);
        if(otp == null)
        {
            ViewBag.Error = "Email không tồn tại trên hệ thống hoặc tài khoản đang bị khóa";
            return View("~/Views/Authentication/ForgotPassword.cshtml");
        }
        HttpContext.Session.SetString("EmailForgot", email);
        HttpContext.Session.SetString("OTP", otp);
        HttpContext.Session.SetString("Timeout",DateTime.Now.AddMinutes(5).Ticks.ToString());
        return Redirect("/verify-otp");
    }
    
}