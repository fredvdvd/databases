using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStore.Data
{
    public class MusicStoreDB
    {
        public static SqlConnection GetConnection()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "DESKTOP-79EAPS5\\SQLEXPRESS";
            builder.InitialCatalog = "MvcMusicStore";
            builder.IntegratedSecurity = true;
            string connectionString = builder.ConnectionString;

            SqlConnection connection = new SqlConnection(connectionString);
            return connection;
        }
    }
}
