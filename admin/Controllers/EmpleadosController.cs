using Microsoft.AspNetCore.Mvc;

namespace admin.Controllers
{
    public class EmpleadosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
