using CatBaBooking.Service.Interface.Auth;
using CatBaBooking.Utils;
using Microsoft.AspNetCore.Mvc;

namespace CatBaBooking.Controllers.Authentication;
[Route("register-customer")]
public class registerCustomerController : Controller
{
    private readonly IRegisterCustomerService reg;
    public registerCustomerController(IRegisterCustomerService reg)
    {
        this.reg = reg;
    }
    // GET
    public IActionResult Index()
    {
        return View("~/Views/Authentication/RegisterCustomer.cshtml");
    }

    [HttpPost]
    public async Task<IActionResult> RegisterCustomer(string fullname, string email, string password,
        string confirmPassword)
    {
        if (string.IsNullOrEmpty(fullname) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confirmPassword))
        {
            ViewBag.Error = "Thông tin không được để trống";
            return View("~/Views/Authentication/RegisterCustomer.cshtml");
        }

        if (!password.Equals(confirmPassword))
        {
            ViewBag.Error = "Mật khẩu và xác nhận mật khẩu không khớp";
            return View("~/Views/Authentication/RegisterCustomer.cshtml");
        }

        if (!PasswordUtils.IsStrongPassword(password))
        {
            ViewBag.Error = "Mật khẩu không hợp lệ! Yêu cầu: Độ dài từ 8 ký tự trở lên, phải bao gồm chữ hoa (A-Z), chữ thường (a-z), chữ số (0-9) và ký tự đặc biệt (như @, $, !, %, *, ?, &).";
            return View("~/Views/Authentication/RegisterCustomer.cshtml");
        }

        int roleId = 1;
        bool isSuccess = await reg.RegisterCustomerAsync(email, password, fullname, roleId);
        if (!isSuccess)
        {
            ViewBag.Error = "Email này đã được đăng kí";
            return View("~/Views/Authentication/RegisterCustomer.cshtml");
        }
        TempData["SuccessMessage"] = "Đăng ký tài khoản thành công! Vui lòng đăng nhập.";
        return Redirect("/login");
    }
}