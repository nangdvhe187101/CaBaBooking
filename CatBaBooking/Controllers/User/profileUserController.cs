using Microsoft.AspNetCore.Mvc;

namespace CatBaBooking.Controllers.User;
[Route("profile-user")]
public class profileUserController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View("~/Views/User/ProfileUser.cshtml");
    }
}