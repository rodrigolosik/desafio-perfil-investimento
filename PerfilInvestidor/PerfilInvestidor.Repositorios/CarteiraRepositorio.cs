using Dapper;
using PerfilInvestidor.Modelos.Carteira;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace PerfilInvestidor.Repositorios
{
    public class CarteiraRepositorio : ICarteiraRepositorio
    {
        public IEnumerable<Carteira> Listar()
        {
            try
            {
                using (var conexaoBD = new SqlConnection(Utils.Utils.ConnectionString))
                {
                    IEnumerable<Carteira> carteiras = conexaoBD.Query<Carteira>($"SELECT * FROM Carteiras");
                    return carteiras;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
