using Newtonsoft.Json;
using PerfilInvestidor.Modelos.Usuario;
using System.Web.Mvc;

namespace PerfilInvestidor.Apresentacao.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var usuario = PegarUsuarioCookie();
            if (usuario == null) return RedirectToAction("Login", "Usuarios");

            ViewBag.NomeUsuario = usuario.Nome;

            return View();
        }

        private Usuario PegarUsuarioCookie()
        {
            var cookie = Request.Cookies["usuarioCookie"];

            if (cookie != null)
                return JsonConvert.DeserializeObject<Usuario>(cookie.Value);
            else
                return null;
        }
    }
}