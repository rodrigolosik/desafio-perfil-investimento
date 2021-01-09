using Newtonsoft.Json;
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
        public void Adicionar(CadastroViewModel usuarioViewModel)
        {
            var repo = new UsuarioRepositorio();
            var usuario = new Usuario
            {
                Nome = usuarioViewModel.Nome,
                Email = usuarioViewModel.Email,
                Senha = HashValue(usuarioViewModel.Senha)
            };

            repo.Adicionar(usuario);
        }

        public void Alterar(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public Usuario Selecionar(int id)
        {
            var repo = new UsuarioRepositorio();
            return repo.Selecionar(id);
        }

        public IEnumerable<Usuario> Listar()
        {
            var repo = new UsuarioRepositorio();
            return repo.Listar();
        }

        public Usuario ValidarLogin(LoginViewModel loginViewModel)
        {
            var usuarios = Listar();

            var usuario = usuarios.Where(u => u.Email == loginViewModel.Email && u.Senha == HashValue(loginViewModel.Senha)).FirstOrDefault();

            return usuario;

        }

        public HttpCookie GerarCookie(Usuario usuario)
        {
            HttpCookie cookie = new HttpCookie("usuarioCookie")
            {
                Value = JsonConvert.SerializeObject(usuario),
                Expires = DateTime.Now.AddHours(1)
            };

            return cookie;
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

    }
}
