using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAFE.Negocios
{
    class Registro_Pagos
    {
        #region Campos
        private int _rpagId;
        private int _rpagIdContrato;
        private long _rpagMontoPago;
        private DateTime _rpagFecha;
        #endregion

        #region Propiedades
        public int RpagId { get => _rpagId; set => _rpagId = value; }
        public int RpagIdContrato { get => _rpagIdContrato; set => _rpagIdContrato = value; }
        public long RpagMontoPago { get => _rpagMontoPago; set => _rpagMontoPago = value; }
        public DateTime RpagFecha { get => _rpagFecha; set => _rpagFecha = value; }
        #endregion

        #region Constructor
        public Registro_Pagos(int rpagId, int rpagIdContrato, long rpagMontoPago, DateTime rpagFecha)
        {
            _rpagId = rpagId;
            _rpagIdContrato = rpagIdContrato;
            _rpagMontoPago = rpagMontoPago;
            _rpagFecha = rpagFecha;
        }

        public Registro_Pagos()
        {
            _rpagId = 0;
            _rpagIdContrato = 0;
            _rpagMontoPago = 0;
            _rpagFecha = DateTime.MinValue;
        }
        #endregion

        #region Metodos
        #endregion
    }
}
