using Dapper;
using PerfilInvestidor.Modelos.Suitability;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace PerfilInvestidor.Repositorios
{
    public class SuitabilityRepositorio : ISuitabilityRepositorio
    {
        const string ConnectionString = "Data Source=DESKTOP-LIPBPBP;Initial Catalog=PerfilInvestidor;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public void SalvarRelacaoUsuarioResposta(int usuarioId, int respostaId)
        {
            try
            {
                using (var conexaoBD = new SqlConnection(ConnectionString))
                {
                    conexaoBD.Execute($"INSERT INTO UsuariosRespostas (UsuarioId, RespostaId) values (@usuarioId, @respostaId)", new { usuarioId, respostaId });
                }
            }
            catch (Exception)
            {
            }
        }

        public void LimparRelacionamentoUsuarioResposta(int usuarioId)
        {
            try
            {
                using (var conexaoBD = new SqlConnection(ConnectionString))
                {
                    conexaoBD.Execute($"DELETE FROM UsuariosRespostas where Id = @usuarioId", usuarioId);
                }
            }
            catch (Exception)
            {
            }
        }

        public Suitability Selecionar()
        {
            using (var conexaoBD = new SqlConnection(ConnectionString))
            {
                return new Suitability();
            }
        }

        public IEnumerable<UsuarioResposta> ListarRespostasPorUsuario(int usuarioId)
        {
            try
            {
                using (var conexaoBD = new SqlConnection(ConnectionString))
                {
                    IEnumerable<UsuarioResposta> usuarios = conexaoBD.Query<UsuarioResposta>($"SELECT * FROM UsuariosRespostas WHERE UsuarioId = @UsuarioId", new { usuarioId });
                    return usuarios;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
