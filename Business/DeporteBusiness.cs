using Data;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class DeporteBusiness
    {
        private DeporteDao _deporteDao;

        public DeporteBusiness() 
        {
            _deporteDao = new DeporteDao();
        }

        public List<Deporte> ObtenerDeportes()
        {
            return _deporteDao.ObtenerDeportes();
        }
    }
}
