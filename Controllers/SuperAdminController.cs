using Microsoft.AspNetCore.Mvc;

namespace LostArkOffice.Controllers
{
    public class SuperAdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
