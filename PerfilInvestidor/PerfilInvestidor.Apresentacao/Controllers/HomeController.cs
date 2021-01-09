using System.Web.Mvc;

namespace PerfilInvestidor.Apresentacao.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if(Request.Cookies["usuarioCookie"] == null )
            {
                return RedirectToAction("Login","Usuarios");
            }

            return View();
        }
    }
}