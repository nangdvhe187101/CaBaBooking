using Microsoft.AspNetCore.Mvc;

namespace CatBaBooking.Controllers.HomePage;
[Route("confirmation-payment")]
public class confirmationPaymentController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View("~/Views/Home/ConfirmationPayment.cshtml");
    }
}