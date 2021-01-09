using Dapper;
using PerfilInvestidor.Modelos.Usuario;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace PerfilInvestidor.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        const string ConnectionString = "Data Source=DESKTOP-LIPBPBP;Initial Catalog=PerfilInvestidor;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public void Adicionar(Usuario usuario)
        {
            using (var conexaoBD = new SqlConnection(ConnectionString))
            {
                var usuarios = conexaoBD.Execute($"INSERT INTO Usuario (Nome, Email, Senha) values (@Nome, @Email, @Senha)", usuario);
            }
        }

        public void Alterar(Usuario usuario)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Usuario> Listar()
        {
            using (var conexaoBD = new SqlConnection(ConnectionString))
            {
                IEnumerable<Usuario> usuarios = conexaoBD.Query<Usuario>($"SELECT * FROM Usuario");
                return usuarios;
            }
        }

        public Usuario Selecionar(int id)
        {
            using (var conexaoBD = new SqlConnection(ConnectionString))
            {
                var usuario = conexaoBD.Query<Usuario>($"SELECT * FROM Usuario WHERE Id = @Id", id).FirstOrDefault();
                return usuario;
            }
        }
    }
}
