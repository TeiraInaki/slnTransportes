using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Entidades;

namespace Datos
{
    public static class AdmAuto
    {
        public static List<Auto> Listar()
        {
            string query = "SELECT Id,Marca,Modelo,Matricula,Precio FROM dbo.Auto";

            SqlCommand command = new SqlCommand(query, AdminBD.ConectarBD());

            SqlDataReader reader;
            reader = command.ExecuteReader();

            List<Auto> autos = new List<Auto>();

            while (reader.Read())
            {
                autos.Add(new Auto()
                {
                    Id = (int)reader["Id"],
                    Marca = (string)reader["Marca"],
                    Modelo = (string)reader["Modelo"],
                    Matricula = (string)reader["Matricula"],
                    Precio = (decimal)reader["Precio"]                  
               });
            }

            reader.Close();
            AdminBD.ConectarBD().Close();

            return autos;
        }

        public static DataTable Listar(string Marca)
        {
            string query = "SELECT Id,Marca,Modelo,Matricula,Precio FROM dbo.Auto WHERE Marca = @Marca";

            SqlDataAdapter adapter = new SqlDataAdapter(query, AdminBD.ConectarBD());
            adapter.SelectCommand.Parameters.Add("@Marca", SqlDbType.VarChar, 50).Value = Marca;

            DataSet ds = new DataSet();

            adapter.Fill(ds, "Autos");

            return ds.Tables["Autos"];
        }

        public static DataTable ListarMarcas()
        {
            string query = "SELECT DISTINCT Marca FROM dbo.Auto";

            SqlDataAdapter adapter = new SqlDataAdapter(query, AdminBD.ConectarBD());

            DataSet ds = new DataSet();

            adapter.Fill(ds, "Marcas");

            return ds.Tables["Marcas"];
        }

        public static int Insertar(Auto auto)
        {
            string query = "INSERT INTO dbo.Auto (Marca,Modelo,Matricula,Precio) VALUES (@Marca,@Modelo,@Matricula,@Precio)";

            SqlCommand command = new SqlCommand(query, AdminBD.ConectarBD());

            command.Parameters.Add("@Marca", SqlDbType.VarChar, 50).Value = auto.Marca;
            command.Parameters.Add("@Modelo", SqlDbType.VarChar, 50).Value = auto.Modelo;
            command.Parameters.Add("@Matricula", SqlDbType.Char, 6).Value = auto.Matricula;
            command.Parameters.Add("@Precio", SqlDbType.Decimal).Value = auto.Precio;

            int filasAfectadas = command.ExecuteNonQuery();
            AdminBD.ConectarBD().Close();
            return filasAfectadas;
        }

        public static int Modificar(Auto auto)
        {
            string query = "UPDATE dbo.Auto SET Marca=@Marca,Modelo=@Modelo,Matricula=@Matricula,Precio=@Precio WHERE Id = @Id";

            SqlCommand command = new SqlCommand(query, AdminBD.ConectarBD());

            command.Parameters.Add("@Marca", SqlDbType.VarChar, 50).Value = auto.Marca;
            command.Parameters.Add("@Modelo", SqlDbType.VarChar, 50).Value = auto.Modelo;
            command.Parameters.Add("@Matricula", SqlDbType.Char, 6).Value = auto.Matricula;
            command.Parameters.Add("@Precio", SqlDbType.Decimal).Value = auto.Precio;
            command.Parameters.Add("@Id", SqlDbType.Int).Value = auto.Id;
            
            int filasAfectadas = command.ExecuteNonQuery();
            AdminBD.ConectarBD().Close();
            return filasAfectadas;
        }

        public static int Eliminar(int Id)
        {
            string query = "DELETE FROM dbo.Auto WHERE Id = @Id";

            SqlCommand command = new SqlCommand(query, AdminBD.ConectarBD());

            command.Parameters.Add("@Id", SqlDbType.Int).Value = Id;

            int filasAfectadas = command.ExecuteNonQuery();
            AdminBD.ConectarBD().Close();
            return filasAfectadas;
        }
    }
}
