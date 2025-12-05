using GNOC.Data;
using GNOC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Text.Json;

namespace GNOC.Controllers
{
    public class TasksController : Controller
    {
        private readonly AppDbContext _context;
        public TasksController(AppDbContext context) => _context = context;
        
        // GET: TasksController
        public ActionResult Index()
        {
            //Caso usuário não esteja logado
            if (HttpContext.Session.GetString("UserProfile") == null)
            {
                return Redirect("/Account/Login");
            }
            return View();
        }
        // GET: TasksController
        public List<GNOC.Models.Task> Show()
        {
            //Caso usuário não esteja logado
            if (HttpContext.Session.GetString("UserProfile") == null)
            {
                return null;
            }

            var tasks = _context.Tasks
                .OrderBy(t => t.PrioritLevel)
                .ToList();
            return tasks;
        }

        // GET: TasksController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TasksController/Create
        [HttpPost]
        public string Create()
        {
            return "teste";
        }

        // GET: TasksController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TasksController/Edit/5
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

        // GET: TasksController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TasksController/Delete/5
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
