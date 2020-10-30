using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAFE.Negocios
{
    class Visita_Terreno
    {
        #region Campos
        private int _visId;
        private String _visRutTrabajador;
        private String _visRutCliente;
        private DateTime _visFecha;
        #endregion

        #region Propiedades
        public int VisId { get => _visId; set => _visId = value; }
        public string VisRutTrabajador { get => _visRutTrabajador; set => _visRutTrabajador = value; }
        public string VisRutCliente { get => _visRutCliente; set => _visRutCliente = value; }
        public DateTime VisFecha { get => _visFecha; set => _visFecha = value; }
        #endregion

        #region Constructor
        public Visita_Terreno(int visId, string visRutTrabajador, string visRutCliente, DateTime visFecha)
        {
            _visId = visId;
            _visRutTrabajador = visRutTrabajador;
            _visRutCliente = visRutCliente;
            _visFecha = visFecha;
        }
        public Visita_Terreno()
        {
            _visId = 0;
            _visRutTrabajador = string.Empty;
            _visRutCliente = string.Empty;
            _visFecha = DateTime.MinValue;
        }
        #endregion

        #region Metodos
        #endregion
    }
}
