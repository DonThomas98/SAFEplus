using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAFE.Negocios
{
    class Tipo_Contacto
    {
        #region Campos
        private int _tconId;
        private String _tconDescripcion;
        private long _tconCosto;
        #endregion

        #region Propiedades
        public int TconId { get => _tconId; set => _tconId = value; }
        public string TconDescripcion { get => _tconDescripcion; set => _tconDescripcion = value; }
        public long TconCosto { get => _tconCosto; set => _tconCosto = value; }
        #endregion

        #region Constructor
        public Tipo_Contacto(int tconId, string tconDescripcion, long tconCosto)
        {
            _tconId = tconId;
            _tconDescripcion = tconDescripcion;
            _tconCosto = tconCosto;
        }

        public Tipo_Contacto()
        {
            _tconId = 0;
            _tconDescripcion = string.Empty;
            _tconCosto = 0;
        }
        #endregion

        #region Metodos
        #endregion
    }
}
