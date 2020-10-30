using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAFE.Negocios
{
    class Tipo_Accidente
    {
        #region Campos
        private int _taccId;
        private String _taccDescipcion;
        #endregion

        #region Propiedades
        public int TaccId { get => _taccId; set => _taccId = value; }
        public string TaccDescipcion { get => _taccDescipcion; set => _taccDescipcion = value; }
        #endregion

        #region Constructor
        public Tipo_Accidente(int taccId, string taccDescipcion)
        {
            _taccId = taccId;
            _taccDescipcion = taccDescipcion;
        }

        public Tipo_Accidente()
        {
            _taccId = 0;
            _taccDescipcion = string.Empty;
        }
        #endregion

        #region Metodos
        #endregion
    }
}
