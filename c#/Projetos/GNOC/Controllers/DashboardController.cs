using Microsoft.AspNetCore.Mvc;

namespace GNOC.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            //Caso usuário não esteja logado
            if (HttpContext.Session.GetString("UserProfile") == null)
            {
                return Redirect("/Account/Login");
            }
            return View();
        }
    }
}
