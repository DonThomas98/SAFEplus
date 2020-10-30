using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAFE.Negocios
{
    class Capacitacion
    {
        #region Campos
        private int _capId;
        private DateTime _capFechaSolicitud;
        private DateTime _capFechaCapacitacion;
        private int _capRutTrabajador;
        private int _capRutCliente;
        #endregion

        #region Propiedades
        public int CapId { get => _capId; set => _capId = value; }
        public DateTime CapFechaSolicitud { get => _capFechaSolicitud; set => _capFechaSolicitud = value; }
        public DateTime CapFechaCapacitacion { get => _capFechaCapacitacion; set => _capFechaCapacitacion = value; }
        public int CapRutTrabajador { get => _capRutTrabajador; set => _capRutTrabajador = value; }
        public int CapRutCliente { get => _capRutCliente; set => _capRutCliente = value; }
        #endregion

        #region Constructor
        public Capacitacion()
        {
            _capId = 0;
            _capFechaSolicitud = DateTime.MinValue;
            _capFechaCapacitacion = DateTime.MinValue;
            _capRutTrabajador = 0;
            _capRutCliente = 0;
        }

        public Capacitacion(int capId, DateTime capFechaSolicitud, DateTime capFechaCapacitacion, int capRutTrabajador, int capRutCliente)
        {
            _capId = capId;
            _capFechaSolicitud = capFechaSolicitud;
            _capFechaCapacitacion = capFechaCapacitacion;
            _capRutTrabajador = capRutTrabajador;
            _capRutCliente = capRutCliente;
        }
        #endregion

        #region Metodos

        #endregion
    }
}
