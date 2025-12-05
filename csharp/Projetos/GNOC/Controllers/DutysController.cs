using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GNOC.Controllers
{
    public class DutysController : Controller
    {
        // GET: DutysController
        public ActionResult Index()
        {
            //Caso usuário não esteja logado
            if (HttpContext.Session.GetString("UserProfile") == null)
            {
                return Redirect("/Account/Login");
            }

            return View();
        }

        // GET: DutysController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DutysController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DutysController/Create
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

        // GET: DutysController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DutysController/Edit/5
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

        // GET: DutysController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DutysController/Delete/5
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
