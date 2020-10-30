using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAFE.Negocios
{
    class Registro_Accidentados
    {
        #region Campos
        private int _raccId;
        private int _raccIdAccidente;
        private String _raccRutTrabajador;
        #endregion

        #region Propiedades
        public int RaccId { get => _raccId; set => _raccId = value; }
        public int RaccIdAccidente { get => _raccIdAccidente; set => _raccIdAccidente = value; }
        public string RaccRutTrabajador1 { get => _raccRutTrabajador; set => _raccRutTrabajador = value; }
        #endregion

        #region Constructor
        public Registro_Accidentados(int raccId, int raccIdAccidente, string raccRutTrabajador)
        {
            _raccId = raccId;
            _raccIdAccidente = raccIdAccidente;
            _raccRutTrabajador = raccRutTrabajador;
        }

        public Registro_Accidentados()
        {
            _raccId = 0;
            _raccIdAccidente = 0;
            _raccRutTrabajador = string.Empty;
        }
        #endregion

        #region Metodos
        #endregion
    }
}
