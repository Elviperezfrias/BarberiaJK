using Microsoft.AspNetCore.Mvc;

namespace BarberiaJK.Web.Controllers
{
    public class ServiciosController : Controller
    {
        public IActionResult Index()
        {
            return View(); // Retorna la vista Index.cshtml
        }
    }
}
