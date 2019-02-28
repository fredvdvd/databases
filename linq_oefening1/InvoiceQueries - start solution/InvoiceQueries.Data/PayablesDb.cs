using System.Configuration;
using System.Data.SqlClient;

namespace InvoiceQueries.Data
{
    internal static class PayablesDb
    {
        public static SqlConnection GetConnection()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["PayablesConnectionString"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            return connection;
        }
    }
}
