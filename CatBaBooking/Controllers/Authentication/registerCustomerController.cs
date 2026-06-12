using Microsoft.AspNetCore.Mvc;

namespace CatBaBooking.Controllers.Authentication;
[Route("register-customer")]
public class registerCustomerController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View("~/Views/Authentication/RegisterCustomer.cshtml");
    }
}