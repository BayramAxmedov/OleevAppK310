using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OleevAppK310.Models;

namespace OleevAppK310.Controllers
{
    [Area("AdminOlev")]
    public class AboutController : Controller
    {
        private readonly OlDbContext _context;              

        private readonly IWebHostEnvironment _env;

        public AboutController(OlDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        // GET: AboutController
        public ActionResult Index()
        {
            return View(_context.AboutUs.ToList());
        }

        // GET: AboutController/Details/5
        public ActionResult Details(int id)
        {

            var AboutUs = _context.AboutUs.FirstOrDefault(s => s.Id == id);
            return View(AboutUs);
        }

        // GET: AboutController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AboutController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AboutUs about, IFormFile PhotoUrl)
        {
            if (ModelState.IsValid)
            {
                if (PhotoUrl != null)
                {
                        string filename = Guid.NewGuid() + PhotoUrl.FileName;
                        string rootPath = Path.Combine(_env.WebRootPath, "images");
                        string photoPath = Path.Combine(rootPath, filename);
                        using FileStream fl = new (photoPath, FileMode.Create);
                        PhotoUrl.CopyTo(fl);
                        about.PhotoUrl = "/images/" + filename;
                }
                _context.AboutUs.Add(about);
                _context.SaveChanges();
                return RedirectToAction("Index");       
            }
            return View();
            
        }

        // GET: AboutController/Edit/5
        public ActionResult Edit(int id)
        {
         var About = _context.AboutUs.FirstOrDefault(AboutUs => AboutUs.Id == id);
            return View(About);
        }

        // POST: AboutController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]              
        public ActionResult Edit(int id, AboutUs about, IFormFile Photo)
        {
            ModelState.ClearValidationState("NewPhoto");
            if (ModelState.IsValid)
            {
                if (Photo != null)
                {
                    string filename = Guid.NewGuid() + Photo.FileName;
                    string rootPath = Path.Combine(_env.WebRootPath, "Images");
                    string photopath = Path.Combine(rootPath, filename);
                    using FileStream fl = new FileStream(photopath, FileMode.Create);
                    Photo.CopyTo(fl);
                    about.PhotoUrl = "/image/" + filename;
                }
                _context.AboutUs.Update(about);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
                return View();
            
        }

        // GET: AboutController/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id==null) return NotFound();    
            return View();
        }

        // POST: AboutController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            var AboutData = _context.AboutUs.Find(id);
            var about = _context.AboutUs.FirstOrDefault(a => a.Id == id);   
            _context.AboutUs.Remove(about);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
