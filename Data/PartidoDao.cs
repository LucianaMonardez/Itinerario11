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
    public class PartidoDao
    {
        public List<Partido> ObtenerPartidos() 
        {
            List<Partido> partidos = new List<Partido>();
            SqlConnection sqlConnection = new SqlConnection(DBConfiguration.GetDbConfig());
            try
            {
                using (sqlConnection)
                {
                    sqlConnection.Open();
                    string query = "SELECT * FROM Partido";
                    SqlCommand command = new SqlCommand(query, sqlConnection);

                    using (command)
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                partidos.Add(MappearPartido(reader));
                            }
                        }
                    }
                }

                return partidos;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void CrearPartido(Partido partido) 
        {
            SqlConnection sqlConnection = new SqlConnection(DBConfiguration.GetDbConfig());
            try
            {
                using (sqlConnection)
                {
                    sqlConnection.Open();
                    string query = "INSERT INTO Partido (Id_Deporte, Equipo_Local, Equipo_Visitante, " +
                        "Fecha_Registro, Fecha_Partido, Marcador_Local, Marcador_Visitante) " +
                        "VALUES (@DeporteId, @EquipoLocal, @EquipoVisitante, " +
                        "@FechaRegistro, @FechaPartido, @MarcadorLocal, @MarcadorVisitante )";

                    using (SqlCommand command = new SqlCommand(query, sqlConnection))
                    {
                        command.Parameters.AddWithValue("@DeporteId", partido.IdDeporte);
                        command.Parameters.AddWithValue("@EquipoLocal", partido.EquipoLocal);
                        command.Parameters.AddWithValue("@EquipoVisitante", partido.EquipoVisitante);
                        command.Parameters.AddWithValue("@FechaRegistro", partido.FechaRegistro);
                        command.Parameters.AddWithValue("@FechaPartido", partido.FechaPartido);
                        command.Parameters.AddWithValue("@MarcadorLocal", partido.MarcadorLocal);
                        command.Parameters.AddWithValue("@MarcadorVisitante", partido.MarcadorVisitante);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void EliminarPartido(int partidoId) 
        {
            SqlConnection sqlConnection = new SqlConnection(DBConfiguration.GetDbConfig());
            try
            {
                using (sqlConnection)
                {
                    sqlConnection.Open();
                    string query = "DELETE FROM Partido WHERE Id_Partido = @Id";
                    SqlCommand command = new SqlCommand(query, sqlConnection);
                    using (command)
                    {
                        command.Parameters.AddWithValue("@Id", partidoId);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void ActualizarMarcadorPartido(Partido partido) 
        {
            SqlConnection sqlConnection = new SqlConnection(DBConfiguration.GetDbConfig());
            try
            {
                using (sqlConnection)
                {
                    sqlConnection.Open();
                    string query = "UPDATE Partido SET Marcador_Local = @MarcadorLocal, Marcador_Visitante = @MarcadorVisitante WHERE Id_Partido = @Id";
                    SqlCommand command = new SqlCommand(query, sqlConnection);
                    using (command)
                    {
                        command.Parameters.AddWithValue("@Id", partido.IdPartido);
                        command.Parameters.AddWithValue("@MarcadorLocal", partido.MarcadorLocal);
                        command.Parameters.AddWithValue("@MarcadorVisitante", partido.MarcadorVisitante);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private Partido MappearPartido(SqlDataReader reader)
        {

            return new Partido(
                Convert.ToInt32(reader["Id_Partido"]),
                Convert.ToInt32(reader["Id_Deporte"]),
                Convert.ToString(reader["Equipo_Local"]),
                Convert.ToString(reader["Equipo_Visitante"]),
                Convert.ToDateTime(reader["Fecha_Registro"]),
                Convert.ToDateTime(reader["Fecha_Partido"]),
                Convert.ToInt32(reader["Marcador_Local"]),
                Convert.ToInt32(reader["Marcador_Visitante"]));
        }
    }
}
