using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAFE.Negocios
{
    class Material_Capacitaciones
    {
        #region Campos
        private int _matId;
        private String _matMaterial;
        #endregion

        #region Propiedades
        public int MatId { get => _matId; set => _matId = value; }
        public string MatMaterial { get => _matMaterial; set => _matMaterial = value; }
        #endregion

        #region Constructor
        public Material_Capacitaciones(int matId, string matMaterial)
        {
            _matId = matId;
            _matMaterial = matMaterial;
        }

        public Material_Capacitaciones()
        {
            _matId = 0;
            _matMaterial = string.Empty;
        }
        #endregion

        #region Metodos
        #endregion
    }
}
