using PerfilInvestidor.Modelos.Usuario.ViewModels;
using PerfilInvestidor.Servicos;
using System.Web.Mvc;

namespace PerfilInvestidor.Apresentacao.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly IUsuarioServico _usuarioServico = new UsuarioServico();

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
                var usuarioExiste = _usuarioServico.ValidarLogin(usuario);

                if (usuarioExiste != null)
                {
                    var cookie = _usuarioServico.GerarUsuarioCookie(usuarioExiste);

                    Response.Cookies.Add(cookie);

                    return RedirectToAction("Index", "Previdencia");
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
                _usuarioServico.Adicionar(usuario);
                return RedirectToAction(nameof(Login), "Usuarios");
            }
            return View();
        }
    }
}