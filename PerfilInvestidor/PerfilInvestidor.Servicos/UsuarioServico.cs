using Newtonsoft.Json;
using PerfilInvestidor.Modelos.Enumeradores;
using PerfilInvestidor.Modelos.Usuario;
using PerfilInvestidor.Modelos.Usuario.ViewModels;
using PerfilInvestidor.Repositorios;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace PerfilInvestidor.Servicos
{
    public class UsuarioServico : IUsuarioServico
    {
        private readonly IUsuarioRepositorio _repo = new UsuarioRepositorio();

        public void Adicionar(CadastroViewModel usuarioViewModel)
        {

            //TODO: Melhorar a conversão da viewModel pra model
            var usuario = new Usuario
            {
                Nome = usuarioViewModel.Nome,
                Email = usuarioViewModel.Email,
                Senha = HashValue(usuarioViewModel.Senha)
            };

            //TODO: Adicionar validação para saber se o email já foi cadastrado;

            _repo.Adicionar(usuario);
        }

        public IEnumerable<Usuario> Listar()
        {
            return _repo.Listar();
        }

        public Usuario ValidarLogin(LoginViewModel loginViewModel)
        {
            var usuarios = Listar();
            return usuarios.Where(u => u.Email == loginViewModel.Email && u.Senha == HashValue(loginViewModel.Senha)).FirstOrDefault();
        }

        public HttpCookie GerarUsuarioCookie(Usuario usuario)
        {
            HttpCookie cookie = new HttpCookie("usuarioCookie")
            {
                Value = JsonConvert.SerializeObject(usuario),
                Expires = DateTime.Now.AddHours(1)
            };
            return cookie;
        }

        public HttpCookie AtualizarUsuarioCookie(Usuario usuario, HttpCookie cookie)
        {
            cookie.Value = JsonConvert.SerializeObject(usuario);
            return cookie;
        }

        public Usuario PegarUsuarioCookie (HttpCookie cookie)
        {
            if (cookie != null)
                return JsonConvert.DeserializeObject<Usuario>(cookie.Value);
            else
                return null;
        }

        public static string HashValue(string value)
        {
            UnicodeEncoding encoding = new UnicodeEncoding();
            byte[] hashBytes;
            using (HashAlgorithm hash = SHA1.Create())
                hashBytes = hash.ComputeHash(encoding.GetBytes(value));

            StringBuilder hashValue = new StringBuilder(hashBytes.Length * 2);
            foreach (byte b in hashBytes)
            {
                hashValue.AppendFormat(CultureInfo.InvariantCulture, "{0:X2}", b);
            }

            return hashValue.ToString();
        }

        public TipoPerfil ClassificarUsuario(ICollection<int> valores)
        {
            var totalPontos = valores.Sum();

            if (totalPontos <= 16)
            {
                return TipoPerfil.Conservador;
            }
            else if (totalPontos >= 17 && totalPontos <= 32)
            {
                return TipoPerfil.Moderado;
            }
            else
            {
                return TipoPerfil.Agressivo;
            }
        }

        public void AtualizarTipoPerfil(int usurioId, ICollection<int> valores)
        {
            var classificacao = ClassificarUsuario(valores);

            _repo.AtualizarTipoPerfil(usurioId, classificacao);
        }

        public Usuario Pegar(int id)
        {
            return _repo.Pegar(id);
        }
    }
}
