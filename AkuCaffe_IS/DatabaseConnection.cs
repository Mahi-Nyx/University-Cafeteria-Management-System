using System.Configuration;
using System.Data.SqlClient;


namespace AkuCaffe_IS
{
    public static class DatabaseConnection
    {
        public static SqlConnection GetConnection()
        {
            string connectionString =
                ConfigurationManager.ConnectionStrings["CafeDB"].ConnectionString;

            return new SqlConnection(connectionString);
        }
    }
}