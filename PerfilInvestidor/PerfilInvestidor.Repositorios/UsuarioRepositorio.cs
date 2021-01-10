using Dapper;
using PerfilInvestidor.Modelos.Enumeradores;
using PerfilInvestidor.Modelos.Usuario;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace PerfilInvestidor.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        public void Adicionar(Usuario usuario)
        {
            try
            {
                using (var conexaoBD = new SqlConnection(Utils.Utils.ConnectionString))
                {
                    var usuarios = conexaoBD.Execute("INSERT INTO Usuarios (Nome, Email, Senha) values (@Nome, @Email, @Senha)", usuario);
                }
            }
            catch (Exception)
            {
            }
        }

        public void AtualizarTipoPerfil(int usuarioId, TipoPerfil tipoPerfil)
        {
            try
            {
                using (var conexaoBD = new SqlConnection(Utils.Utils.ConnectionString))
                {
                    conexaoBD.Execute("UPDATE Usuarios SET TipoPerfil = @TipoPerfil WHERE Id = @usuarioId", new { tipoPerfil, usuarioId });
                }
            }
            catch (Exception)
            {
            }
        }

        public IEnumerable<Usuario> Listar()
        {
            try
            {
                using (var conexaoBD = new SqlConnection(Utils.Utils.ConnectionString))
                {
                    IEnumerable<Usuario> usuarios = conexaoBD.Query<Usuario>("SELECT * FROM Usuarios");
                    return usuarios;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Usuario Pegar(int id)
        {
            try
            {
                using (var conexaoBD = new SqlConnection(Utils.Utils.ConnectionString))
                {
                    Usuario usuario = conexaoBD.QueryFirst<Usuario>("SELECT * FROM Usuarios WHERE Id = @Id", new { id });
                    return usuario;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
