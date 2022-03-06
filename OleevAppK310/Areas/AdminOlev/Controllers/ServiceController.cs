using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OleevAppK310.Models;

namespace OleevAppK310.Areas.AdminOlev.Controllers
{
    [Area("AdminOlev")]
    public class ServiceController : Controller
    {
        private readonly OlDbContext _context;
        private readonly IWebHostEnvironment _env;

        public ServiceController(OlDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        // GET: ServıceController
        public ActionResult Index()
        {
            return View(_context.services.ToList());
        }

        // GET: ServıceController/Details/5
        public ActionResult Details(int id)
        {
            var Service = _context.services.FirstOrDefault(_context => _context.id == id);
            return View(Service);
        }

        // GET: ServıceController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ServıceController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Service service, IFormFile PhotoUrl)
        {
            if (PhotoUrl != null)
            {
                string filename = Guid.NewGuid() + PhotoUrl.FileName;
                string rootPath = Path.Combine(_env.WebRootPath, "images");
                string photoPath = Path.Combine(rootPath, filename);
                using FileStream fl = new(photoPath, FileMode.Create);
                PhotoUrl.CopyTo(fl);
                service.PhotoUrl = "/images/" + filename;

                _context.services.Add(service);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }



        // GET: ServıceController/Edit/5
        public ActionResult Edit(int id)
        {
            var Service = _context.services.FirstOrDefault(x => x.id == id);
            return View(Service);
        }

        // POST: ServıceController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Service service, IFormFile PhotoUrl)
        {
           
                if (PhotoUrl != null)
                {
                    string filename = Guid.NewGuid() + PhotoUrl.FileName;
                    string rootPath = Path.Combine(_env.WebRootPath, "images");
                    string photoPath = Path.Combine(rootPath, filename);
                    using FileStream fl = new(photoPath, FileMode.Create);
                    PhotoUrl.CopyTo(fl);
                    service.PhotoUrl = "/images/" + filename;

                    _context.services.Update(service);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
            
            return View();

        }

        // GET: ServıceController/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null) return NotFound();
            return View();
        }

        // POST: ServıceController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            var ServiceData = _context.services.Find(id);
            var service = _context.services.FirstOrDefault(s => s.id == id);
            _context.services.Remove(service);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
