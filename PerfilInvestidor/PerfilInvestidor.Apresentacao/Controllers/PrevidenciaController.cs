using PerfilInvestidor.Modelos.ViewModels;
using PerfilInvestidor.Servicos;
using System;
using System.Web;
using System.Web.Mvc;

namespace PerfilInvestidor.Apresentacao.Controllers
{
    public class PrevidenciaController : Controller
    {
        private readonly ISuitabilityServico _suitabilityServico = new SuitabilityServico();
        private readonly IUsuarioServico _usuarioServico = new UsuarioServico();
        private readonly ICarteiraServico _carteiraServico = new CarteiraServico();

        public ActionResult CarteirasRecomendadas()
        {
            var cookie = PegarCookie();
            var usuario = _usuarioServico.PegarUsuarioCookie(cookie);
            ViewBag.TipoPerfil = usuario.TipoPerfil.ToString();

            return View(_carteiraServico.Listar());
        }

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Perfil()
        {
            try
            {
                var cookie = PegarCookie();
                var usuario = _usuarioServico.PegarUsuarioCookie(cookie);

                //TODO: Melhorar a forma de passar as respostas pro JS
                ViewData["respostas"] = _suitabilityServico.ListarRespostasPorUsuario(usuario.Id);

                ViewBag.NomePerfil = usuario.TipoPerfil.ToString();

                var questionario = _suitabilityServico.Selecionar();
                return View(questionario);
            }
            catch (Exception)
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public object SalvarPerfil(SuitabilityViewModel suitability)
        {
            var cookie = PegarCookie();
            var usuarioCookie = _usuarioServico.PegarUsuarioCookie(cookie);
            var usuario = _usuarioServico.Pegar(usuarioCookie.Id);

            _suitabilityServico.SalvarRelacaoUsuarioResposta(usuarioCookie.Id, suitability.RespostasIds);
            _usuarioServico.AtualizarTipoPerfil(usuarioCookie.Id, suitability.RespostasValores);

            var novoUsuarioCookie = _usuarioServico.AtualizarUsuarioCookie(usuario, cookie);
            AlterarUsuarioCookie(novoUsuarioCookie);
            //TODO: Melhorar retorno para o JS
            return new { message = "Dados salvos com sucesso! ", status = "sucesso" };
        }

        private HttpCookie PegarCookie()
        {
            return Request.Cookies["usuarioCookie"];
        }

        private void AlterarUsuarioCookie(HttpCookie cookie)
        {
            Response.Cookies.Add(cookie);
        }
    }
}