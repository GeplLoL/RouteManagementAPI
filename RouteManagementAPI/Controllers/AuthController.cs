using Microsoft.AspNetCore.Mvc;

namespace RouteManagementAPI.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
