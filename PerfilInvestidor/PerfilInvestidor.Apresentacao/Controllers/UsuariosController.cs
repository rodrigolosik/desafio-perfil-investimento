using PerfilInvestidor.Modelos.Usuario.ViewModels;
using PerfilInvestidor.Servicos;
using System.Web.Mvc;

namespace PerfilInvestidor.Apresentacao.Controllers
{
    public class UsuariosController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel usuario)
        {
            if (ModelState.IsValid)
            {
                var usuarioServico = new UsuarioServico();

                var usuarioExiste = usuarioServico.ValidarLogin(usuario);

                if(usuarioExiste != null)
                {
                    var cookie = usuarioServico.GerarCookie(usuarioExiste);

                    Response.Cookies.Add(cookie);

                    return RedirectToAction(nameof(Index), "Home");
                }
            }
            return View();
        }

        public ActionResult Logout()
        {
            Response.Cookies.Clear();
            return RedirectToAction("Login", "Usuarios");
        }

        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastrar(CadastroViewModel usuario)
        {
            if (ModelState.IsValid)
            {
                var usuarioServico = new UsuarioServico();

                usuarioServico.Adicionar(usuario);

                return RedirectToAction(nameof(Login), "Usuarios");

            }
            return View();
        }
    }
}