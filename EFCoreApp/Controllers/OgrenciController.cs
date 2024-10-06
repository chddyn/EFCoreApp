using Microsoft.AspNetCore.Mvc;

namespace EFCoreApp.Controllers
{
    public class OgrenciController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
