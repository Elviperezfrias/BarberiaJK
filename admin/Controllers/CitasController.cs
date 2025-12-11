using Microsoft.AspNetCore.Mvc;

namespace admin.Controllers
{
    public class CitasController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}