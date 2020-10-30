using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAFE.Negocios
{
    class Asesoria
    {
        #region Campos
        private int _aseId;
        private String _aseEvento;
        private String _aseProMejora;
        private int _aseIdVisita;

        

        #endregion

        #region Propiedades
        public int AseId { get => _aseId; set => _aseId = value; }
        public string AseEvento { get => _aseEvento; set => _aseEvento = value; }
        public string AseProMejora { get => _aseProMejora; set => _aseProMejora = value; }
        public int AseIdVisita { get => _aseIdVisita; set => _aseIdVisita = value; }
        #endregion

        #region Constructor
        public Asesoria(int aseId, string aseEvento, string aseProMejora, int aseIdVisita)
        {
            _aseId = aseId;
            _aseEvento = aseEvento;
            _aseProMejora = aseProMejora;
            _aseIdVisita = aseIdVisita;
        }
        public Asesoria()
        {
            _aseId = 0;
            _aseEvento = string.Empty;
            _aseProMejora = string.Empty;
            _aseIdVisita = 0;
        }
        #endregion

        #region Metodos
        #endregion
    }
}
