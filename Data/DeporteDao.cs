using Entity;
using Mapper;
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
        public List<Deporte> Deportes = new List<Deporte>();

        public DeporteDao()
        {
            Deportes = ObtenerDeportes();
        }

        private List<Deporte> ObtenerDeportes() 
        {
            List<Deporte> deportes = new List<Deporte>();
            SqlConnection sqlConnection = new SqlConnection(ConnectionUtils.GetDbConfig());

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
                                deportes.Add(DeporteMapper.Map(reader));
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
    }
}
