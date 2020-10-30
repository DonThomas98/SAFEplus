using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAFE.Negocios
{
    class Accidente
    {
        #region Campos
        private int _accId;
        private int _accTipoAccidente;
        private DateTime _accFecha;
        #endregion

        #region Propiedades
        public int AccId { get => _accId; set => _accId = value; }
        public int AccTipoAccidente { get => _accTipoAccidente; set => _accTipoAccidente = value; }
        public DateTime AccFecha { get => _accFecha; set => _accFecha = value; }
        #endregion

        #region Constructor
        public Accidente(int accId, int accTipoAccidente, DateTime accFecha)
        {
            _accId = accId;
            _accTipoAccidente = accTipoAccidente;
            _accFecha = accFecha;
        }

        public Accidente()
        {
            _accId = 0;
            _accTipoAccidente = 0;
            _accFecha = DateTime.MinValue;
        }
        #endregion

        #region Metodos
        #endregion
    }
}
