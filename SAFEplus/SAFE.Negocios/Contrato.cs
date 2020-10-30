using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAFE.Negocios
{
    class Contrato
    {
        #region Campos
        private int _conId;
        private String _conRutCliente;
        private int _conTipoContrato;
        private DateTime _conFecha;
        #endregion

        #region Propiedades
        public int ConId { get => _conId; set => _conId = value; }
        public string ConRutCliente { get => _conRutCliente; set => _conRutCliente = value; }
        public int ConTipoContrato { get => _conTipoContrato; set => _conTipoContrato = value; }
        public DateTime ConFecha { get => _conFecha; set => _conFecha = value; }
        #endregion

        #region Constructor
        public Contrato(int conId, string conRutCliente, int conTipoContrato, DateTime conFecha)
        {
            _conId = conId;
            _conRutCliente = conRutCliente;
            _conTipoContrato = conTipoContrato;
            _conFecha = conFecha;
        }

        public Contrato()
        {
            _conId = 0;
            _conRutCliente = string.Empty;
            _conTipoContrato = 0;
            _conFecha = DateTime.MinValue;
        }
        #endregion

        #region Metodos
        #endregion
    }
}
