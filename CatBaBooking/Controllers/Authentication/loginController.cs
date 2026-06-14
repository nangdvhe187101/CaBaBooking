using CatBaBooking.Service.Interface.Auth;
using Microsoft.AspNetCore.Mvc;

namespace CatBaBooking.Controllers.Authentication;

[Route("login")]
public class loginController : Controller
{
    private readonly ILoginService loginService;
    public loginController(ILoginService loginService)
    {
        this.loginService = loginService;
    }
    // GET
    public IActionResult Index()
    {
        return View("~/Views/Authentication/Login.cshtml");
    }

    [HttpPost]
    public async Task<IActionResult> Login(string email, string password)
    {
        if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
        {
            ViewBag.Error = "Email và mật khẩu không được để trống";
            return View("~/Views/Authentication/Login.cshtml");
        }

        var user = await loginService.LoginAsync(email, password);
        if (user == null)
        {
            ViewBag.Error = "Email mật khẩu không chính xác hoặc tài khoản của bạn đang chờ duyệt.";
            return View("~/Views/Authentication/Login.cshtml");
        }
        HttpContext.Session.SetString("UserId",user.UserId.ToString());
        HttpContext.Session.SetString("UserName",user.FullName);
        HttpContext.Session.SetString("RoleId",user.RoleId.ToString());
        HttpContext.Session.SetString("RoleName",user.Role.RoleName);
        string? role = HttpContext.Session.GetString("RoleName");
        switch (role?.ToLower().Trim())
        {
            case "admin":
                return Redirect("/dash-board");
                break;
            case "ownerhomestay":
                return Redirect("/dash-board");
                break;
            case "ownerrestaurant":
                return Redirect("/dash-board");
                break;
            default:
                return Redirect("/home-page");
                break;
        }
    }
}