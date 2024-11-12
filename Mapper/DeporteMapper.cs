using Entity;
using System.Data.SqlClient;

namespace Mapper
{
    public class DeporteMapper
    {
        public static Deporte Map(SqlDataReader reader) 
        {
            return new Deporte(
                Convert.ToInt32(reader["Id_Deporte"]),
                Convert.ToString(reader["Descripcion"]));
        }
     }
}
