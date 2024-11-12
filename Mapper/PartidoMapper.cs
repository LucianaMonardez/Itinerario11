using Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapper
{
    public class PartidoMapper
    {
        public static Partido Map(SqlDataReader reader, Deporte deporte)
        {
            return new Partido(
               Convert.ToInt32(reader["Id_Partido"]),
               Convert.ToInt32(reader["Id_Deporte"]),
               Convert.ToString(reader["Equipo_Local"]),
               Convert.ToString(reader["Equipo_Visitante"]),
               Convert.ToDateTime(reader["Fecha_Registro"]),
               Convert.ToDateTime(reader["Fecha_Partido"]),
               Convert.ToInt32(reader["Marcador_Local"]),
               Convert.ToInt32(reader["Marcador_Visitante"]),
               deporte);
        }
    }
}
