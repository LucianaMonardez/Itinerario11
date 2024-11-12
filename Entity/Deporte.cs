using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Deporte
    {
        public int IdDeporte { get; set; }
        public string Descripcion { get; set; }

        public Deporte(int idDeporte, string descripcion)
        {
            IdDeporte = idDeporte;
            Descripcion = descripcion;
        }
    }
}
