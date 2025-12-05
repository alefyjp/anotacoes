using GNOC.Data;
using GNOC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace GNOC.Controllers
{
    public class SectorsController : Controller
    {
        private readonly AppDbContext _context;
        public SectorsController(AppDbContext context) => _context = context;

        // GET: SectorController
        public ActionResult Index()
        {
            //Caso usuário não esteja logado
            if (HttpContext.Session.GetString("UserProfile") == null)
            {
                return Redirect("/Account/Login");
            }

            // 
            var sectors = _context.Sectors.ToList<Sector>();
            return View(sectors);
        }

        // GET: SectorController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SectorController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SectorController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SectorController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SectorController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SectorController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SectorController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
