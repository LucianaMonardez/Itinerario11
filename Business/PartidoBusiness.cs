using Data;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class PartidoBusiness
    {
        private PartidoDao _partidoDao;
        private List<Partido> _partidoList;

        public PartidoBusiness() 
        {
            _partidoDao = new PartidoDao();
        }

        public List<Partido> ObtenerPartidos()
        {
            _partidoList = _partidoDao.ObtenerPartidos();
            return _partidoList;
        }

        public void CrearPartido(Partido partido)
        {
            try
            {
                ValidarCamposEquipo(partido.EquipoLocal, "local");
                ValidarCamposEquipo(partido.EquipoVisitante, "visitante");
                if (partido.EquipoVisitante.Length < 5)
                    throw new Exception("El equipo visitante debe tener mas de 5 caracteres");
                if (partido.FechaPartido.Date < DateTime.Now.Date)
                    throw new Exception("La fecha del partido no puede ser menor a la fecha actual");

                _partidoDao.CrearPartido(partido);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void ValidarCamposEquipo(string equipoTxt, string tipoEquipo) 
        {
            if (equipoTxt == "")
                throw new Exception($"El campo equipo {tipoEquipo} no puede estar vacio");
            if (equipoTxt.Length < 5)
                throw new Exception($"El equipo {tipoEquipo} debe tener mas de 5 caracteres");
            if (equipoTxt.Length >= 50)
                throw new Exception($"Hay demasiados caracteres en el campo equipo {tipoEquipo}");

        }

        public void EliminarPartido(string id) 
        {
            try
            {
                Partido partido = ValidarId(id);

                _partidoDao.EliminarPartido(partido.IdPartido);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void ActualizarMarcadorPartido(string id, string marcadorLocal, string marcadorVisitante) 
        {
            try
            {
                ValidarMarcadores(marcadorLocal, marcadorVisitante);
                Partido partido = ValidarId(id);

                //validamos que solo se puedan modificar los partidos de la fecha de hoy
                if (partido.FechaPartido.Date != DateTime.Now.Date)
                    throw new Exception("Solo se pueden modificar los partidos que se jueguen en esta fecha, por favor seleccione otro partido");

                _partidoDao.ActualizarMarcadorPartido(
                    new Partido(partido.IdPartido, 
                    Convert.ToInt32(marcadorLocal), 
                    Convert.ToInt32(marcadorVisitante)));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private Partido ValidarId(string partidoId)
        {
            int id = 0;
            if (!int.TryParse(partidoId, out id))
                throw new ArgumentException("El id ingresado no es valido, por favor ingrese un valor numerico.");
            if (id <= 0)
                throw new ArgumentException("El valor del id debe ser un numero mayor a 0.");
           
            Partido partido = _partidoList.Find(x => x.IdPartido.Equals(Convert.ToInt32(partidoId))) ??
                throw new Exception("No existe un partido con el id ingresado."); 

            return partido;
        }

        private void ValidarMarcadores(string marcadorLocal, string marcadorVisitante) 
        {
            if (marcadorLocal == "")
                throw new Exception("El campo marcador local no puede estar vacio");
            ValidarMarcador(marcadorLocal, "local");

            if (marcadorVisitante == "")
                throw new Exception("El campo marcador visitante no puede estar vacio");
            ValidarMarcador(marcadorVisitante, "visitante");
        }

        private void ValidarMarcador(string marcadorText, string tipoMarcador) 
        {
            int marcador = 0;
            if (!int.TryParse(marcadorText, out marcador))
                throw new ArgumentException($"El marcador {tipoMarcador} ingresado no es válido, por favor ingrese un valor numérico.");
            if (marcador < 0)
                throw new ArgumentException($"El valor ingresado en el marcador {tipoMarcador} debe ser un numero mayor a 0.");
        }
    }
}
