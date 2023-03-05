using Microsoft.AspNetCore.Mvc;

namespace DineDash.Controllers
{
    public class HomeController : Controller
    {

      [HttpGet("/")]
      public ActionResult Index()
      {
        return View();
      }

    }
}