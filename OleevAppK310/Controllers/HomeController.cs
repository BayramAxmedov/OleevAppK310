using Microsoft.AspNetCore.Mvc;
using OleevAppK310.Models;
using OleevAppK310.ViewModel;
using System.Diagnostics;

namespace OleevAppK310.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly OlDbContext _context;
        public HomeController(ILogger<HomeController> logger, OlDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {

            IndexVm vm = new();
            vm.Section1Info = _context.Section1s.FirstOrDefault();
            vm.Services = _context.services.ToList();
            vm.Doctors = _context.Doctors.ToList();
            vm.ReservCategories = _context.ReservCategory.ToList();
            vm.AboutUs = _context.AboutUs.FirstOrDefault();
            vm.SaleProduct = _context.saleProducts.FirstOrDefault();
            vm.Facts = _context.Fatcs.ToList();


            return View(vm);
        }
        [HttpPost]
        public JsonResult MakeAppointment(Reserv reserv)
        {

            var res = new JsonResult(new{ });
            try
            {
                _context.reservs.Add(reserv);
                _context.SaveChanges();
                res.Value = new { message = "Melumatiniz qeyde alinib", status = true };
            }
            catch (Exception e)
            {
                res.Value = new { message = e.Message, status=false };
            }
            return res;
        }


        [HttpPost]
        public IActionResult GetServiceById(int? id)
        {
            if (id == null) return NotFound();
            var selectedService = _context.services.Find(id);

            return Json(selectedService);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}