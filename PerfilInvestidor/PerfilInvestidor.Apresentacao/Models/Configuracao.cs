using System.Configuration;

namespace PerfilInvestidor.Apresentacao.Models
{
    public static class Configuracao
    {
        private static string connectionString;

        public static string GetConnectionString()
        {
            return connectionString;
        }

        public static void SetConnectionString()
        {
            connectionString = ConfigurationManager.ConnectionStrings["conexaoPadrao"].ConnectionString;
        }
    }
}