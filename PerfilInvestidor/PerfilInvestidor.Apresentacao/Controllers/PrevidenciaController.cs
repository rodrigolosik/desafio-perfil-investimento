using Newtonsoft.Json;
using PerfilInvestidor.Modelos.Usuario;
using PerfilInvestidor.Modelos.ViewModels;
using PerfilInvestidor.Servicos;
using System.Web.Mvc;

namespace PerfilInvestidor.Apresentacao.Controllers
{
    public class PrevidenciaController : Controller
    {
        private readonly SuitabilityServico _servico = new SuitabilityServico();
        private readonly UsuarioServico _usuarioServico = new UsuarioServico();

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Perfil()
        {
            var usuario = PegarUsuarioCookie();
            ValidarSessao();

            var respostas = _servico.ListarRespostasPorUsuario(usuario.Id);

            ViewData["respostas"] = respostas;

            var questionario = _servico.SelecionarMock();
            return View(questionario);
        }

        [HttpPost]
        public object SalvarPerfil(SuitabilityViewModel suitability)
        {
            var usuario = PegarUsuarioCookie();

            ValidarSessao();

            _servico.SalvarRelacaoUsuarioResposta(usuario.Id, suitability.RespostasIds);

            _usuarioServico.AtualizarTipoPerfil(usuario.Id, suitability.RespostasValores);

            return new { message = "Dados salvos com sucesso! ", status = "sucesso" };

        }

        private Usuario PegarUsuarioCookie()
        {
            var cookie = Request.Cookies["usuarioCookie"];

            if (cookie != null)
                return JsonConvert.DeserializeObject<Usuario>(cookie.Value);
            else
                return null;
        }

        private ActionResult ValidarSessao()
        {
            var usuario = PegarUsuarioCookie();
            if (usuario == null)
                return RedirectToAction("Login", "Usuarios");

            return null;
        }
    }
}