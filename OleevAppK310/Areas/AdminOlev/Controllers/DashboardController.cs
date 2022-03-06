using Microsoft.AspNetCore.Mvc;

namespace OleevAppK310.Areas.AdminOlev.Controllers
{
    [Area("AdminOlev")]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
