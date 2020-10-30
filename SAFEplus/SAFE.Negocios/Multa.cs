using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAFE.Negocios
{
    class Multa
    {
        #region Campos
        private int _mulId;
        private String _mulRutCliente;
        private long _mulMonto;
        private String _mulDescripcion;
        private DateTime _mulFecha;
        #endregion

        #region Propiedades
        public int MulId { get => _mulId; set => _mulId = value; }
        public string MulRutCliente { get => _mulRutCliente; set => _mulRutCliente = value; }
        public long MulMonto { get => _mulMonto; set => _mulMonto = value; }
        public string MulDescripcion { get => _mulDescripcion; set => _mulDescripcion = value; }
        public DateTime MulFecha { get => _mulFecha; set => _mulFecha = value; }
        #endregion

        #region Constructor
        public Multa(int mulId, string mulRutCliente, long mulMonto, string mulDescripcion, DateTime mulFecha)
        {
            _mulId = mulId;
            _mulRutCliente = mulRutCliente;
            _mulMonto = mulMonto;
            _mulDescripcion = mulDescripcion;
            _mulFecha = mulFecha;

        }
        public Multa()
        {
            _mulId = 0;
            _mulRutCliente = string.Empty;
            _mulMonto = 0;
            _mulDescripcion = string.Empty;
            _mulFecha = DateTime.MinValue;
        }
        #endregion

        #region Metodos
        #endregion
    }
}
