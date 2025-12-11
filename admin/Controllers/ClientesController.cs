using Microsoft.AspNetCore.Mvc;

namespace admin.Controllers
{
    public class ClientesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
