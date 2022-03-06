using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OleevAppK310.Models;

namespace OleevAppK310.Areas.AdminOlev.Controllers
{
    [Area("AdminOlev")]
    public class DoctorController : Controller
    {

        private readonly OlDbContext _context;
        private readonly IWebHostEnvironment _env;

        public DoctorController(OlDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        // GET: DoctorController
        public ActionResult Index()
        {
            return View(_context.Doctors.ToList());
        }

        // GET: DoctorController/Details/5
        public ActionResult Details(int id)
        {
            var doctor = _context.Doctors.FirstOrDefault(doc => doc.Id == id);
            return View(doctor);
        }

        // GET: DoctorController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DoctorController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Doctor doctor, IFormFile PhotoUrl)
        {
                if(PhotoUrl != null)
                {
                    string filename = Guid.NewGuid() + PhotoUrl.FileName;
                    string rootPath = Path.Combine(_env.WebRootPath, "images");
                    string photoPath = Path.Combine(rootPath, filename);
                    using FileStream fl = new FileStream(photoPath, FileMode.Create);
                PhotoUrl.CopyTo(fl);
                    doctor.PhotoUrl = "/images/" + filename;
                }
                _context.Doctors.Add(doctor);
            _context.SaveChanges();
                return RedirectToAction("Index");   
            
           
        }

        // GET: DoctorController/Edit/5
        public ActionResult Edit(int id)
        {
            var Doctor = _context.Doctors.FirstOrDefault(doctor => doctor.Id == id);    
            return View();
        }

        // POST: DoctorController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Doctor doctor, IFormFile? Photo)
        {
            ModelState.ClearValidationState("NewPhoto");
            if (ModelState.IsValid)
            {
                if(Photo != null)
                {
                    string filename = Guid.NewGuid() +Photo.FileName;
                    string rootPath = Path.Combine(_env.WebRootPath, "images");
                    string photoPath =Path.Combine(rootPath, filename);
                    using FileStream fl = new FileStream(photoPath, FileMode.Create);
                    Photo.CopyTo(fl);
                    doctor.PhotoUrl = "/images/" + filename;    
                }
                _context.Doctors.Update(doctor);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
                return View();
            
        }

        // GET: DoctorController/Delete/5
        public ActionResult Delete(int? id)
        {
            if(id==null) return NotFound();
            return View();
        }

        // POST: DoctorController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            var DoctorData = _context.Doctors.Find(id); 
            var doctor = _context.Doctors.FirstOrDefault(x => x.Id == id);  
            _context.Doctors.Remove(doctor);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
