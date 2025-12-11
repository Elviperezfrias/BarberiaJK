using Microsoft.AspNetCore.Mvc;

namespace BarberiaJK.ARMY.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Registro()
        {
            return View();
        }
    }
}
