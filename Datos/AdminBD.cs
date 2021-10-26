using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Datos
{
    internal static class AdminBD
    {
        internal static SqlConnection ConectarBD()
        {
            string Key = Datos.Properties.Settings.Default.KeyDBTransporte;

            SqlConnection connection = new SqlConnection(Key);

            connection.Open();
            return connection;
        }
    }
}
