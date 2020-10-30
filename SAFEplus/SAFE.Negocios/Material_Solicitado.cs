using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAFE.Negocios
{
    class Material_Solicitado
    {
        #region Campos
        private int _solId;
        private int _solIdMaterial;
        private int _solIdCapacitacion;
        private int _solCantidad;
        #endregion

        #region Propiedades
        public int SolId { get => _solId; set => _solId = value; }
        public int SolIdMaterial { get => _solIdMaterial; set => _solIdMaterial = value; }
        public int SolIdCapacitacion { get => _solIdCapacitacion; set => _solIdCapacitacion = value; }
        public int SolCantidad { get => _solCantidad; set => _solCantidad = value; }
        #endregion

        #region Constructor
        public Material_Solicitado(int solId, int solIdMaterial, int solIdCapacitacion, int solCantidad)
        {
            _solId = solId;
            _solIdMaterial = solIdMaterial;
            _solIdCapacitacion = solIdCapacitacion;
            _solCantidad = solCantidad;
        }

        public Material_Solicitado()
        {
            _solId = 0;
            _solIdMaterial = 0;
            _solIdCapacitacion = 0;
            _solCantidad = 0;
        }
        #endregion

        #region Metodos
        #endregion
    }
}
