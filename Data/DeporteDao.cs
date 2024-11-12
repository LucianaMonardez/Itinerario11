using Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class DeporteDao
    {
        public List<Deporte> ObtenerDeportes() 
        {
            List<Deporte> deportes = new List<Deporte>();
            SqlConnection sqlConnection = new SqlConnection(DBConfiguration.GetDbConfig());

            try
            {
                using (sqlConnection)
                {
                    sqlConnection.Open();
                    string query = "SELECT * FROM Deporte";
                    SqlCommand command = new SqlCommand(query, sqlConnection);

                    using (command)
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                deportes.Add(MappearDeporte(reader));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return deportes;
        }

        private Deporte MappearDeporte(SqlDataReader reader)
        {
            return new Deporte(
                Convert.ToInt32(reader["Id_Deporte"]),
                Convert.ToString(reader["Descripcion"]));
        }
    }
}
