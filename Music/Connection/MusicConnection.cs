using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music.Connection
{
    public class MusicConnection
    {
        private const string CERTIFICATE = "TrustServerCertificate=true";

        private const string DATA_SOURCE = "Data Source=DONNA\\SQLEXPRESS";

        private const string CATALOG = "Initial Catalog=Music";

        private const string SECURITY = "Integrated Security=SSPI";

        public static SqlConnection Open()
        {
            SqlConnection connection = new SqlConnection($"{DATA_SOURCE};{CATALOG};{SECURITY};{CERTIFICATE}");
            connection.Open();

            return connection;
        }
    }
}
