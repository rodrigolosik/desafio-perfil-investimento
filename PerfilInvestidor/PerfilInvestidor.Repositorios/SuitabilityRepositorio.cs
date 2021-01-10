using Dapper;
using PerfilInvestidor.Modelos.Suitability;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace PerfilInvestidor.Repositorios
{
    public class SuitabilityRepositorio : ISuitabilityRepositorio
    {
        public void SalvarRelacaoUsuarioResposta(int usuarioId, int respostaId)
        {
            try
            {
                using (var conexaoBD = new SqlConnection(Utils.Utils.ConnectionString))
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
                using (var conexaoBD = new SqlConnection(Utils.Utils.ConnectionString))
                {
                    conexaoBD.Execute($"DELETE FROM UsuariosRespostas where UsuarioId = @UsuarioId", new { usuarioId });
                }
            }
            catch (Exception)
            {
            }
        }

        public IEnumerable<UsuarioResposta> ListarRespostasPorUsuario(int usuarioId)
        {
            try
            {
                using (var conexaoBD = new SqlConnection(Utils.Utils.ConnectionString))
                {
                    IEnumerable<UsuarioResposta> usuarios = conexaoBD.Query<UsuarioResposta>($"SELECT * FROM UsuariosRespostas WHERE UsuarioId = @UsuarioId", new { usuarioId });
                    return usuarios;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
