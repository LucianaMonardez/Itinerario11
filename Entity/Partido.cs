using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Partido
    {
        public int IdPartido { get; set; }
        public int IdDeporte { get; set; }
        public string EquipoLocal { get; set; }
        public string EquipoVisitante { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime FechaPartido { get; set; }
        public int MarcadorLocal { get; set; }
        public int MarcadorVisitante { get; set; }
        public Deporte Deporte { get; set; }
        public string DescripcionDeporte { get => Deporte.Descripcion; }

        public Partido()
        {
        }

        //los campos marcadores se inicializan automaticamente en 0
        public Partido(int idDeporte, string equipoLocal, string equipoVisitante, DateTime fechaPartido)
        {
            IdDeporte = idDeporte;
            EquipoLocal = equipoLocal;
            EquipoVisitante = equipoVisitante;
            FechaPartido = fechaPartido;
            FechaRegistro = DateTime.Now;
        }

        public Partido(int idPartido, int marcadorLocal, int marcadorVisitante)
        {
            IdPartido = idPartido;
            MarcadorLocal = marcadorLocal;
            MarcadorVisitante = marcadorVisitante;
        }

        public Partido(int idPartido, int idDeporte, string equipoLocal, string equipoVisitante, DateTime fechaRegistro, DateTime fechaPartido, int marcadorLocal, int marcadorVisitante)
        {
            IdPartido = idPartido;
            IdDeporte = idDeporte;
            EquipoLocal = equipoLocal;
            EquipoVisitante = equipoVisitante;
            FechaRegistro = fechaRegistro;
            FechaPartido = fechaPartido;
            MarcadorLocal = marcadorLocal;
            MarcadorVisitante = marcadorVisitante;
        }

        public Partido(int idPartido, int idDeporte, string equipoLocal, string equipoVisitante, DateTime fechaRegistro, DateTime fechaPartido, int marcadorLocal, int marcadorVisitante, Deporte deporte) : this(idPartido, idDeporte, equipoLocal, equipoVisitante, fechaRegistro, fechaPartido, marcadorLocal, marcadorVisitante)
        {
            this.Deporte = deporte;
        }
    }
}
