using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAFE.Negocios
{
    class Cargo
    {
        #region Campos
        private int _carId;
        private String _carCargo;
        #endregion

        #region Propiedades
        public int CarId { get => _carId; set => _carId = value; }
        public string CarCargo { get => _carCargo; set => _carCargo = value; }
        #endregion

        #region Constructor
        public Cargo(int carId, string carCargo)
        {
            _carId = carId;
            _carCargo = carCargo;
        }
        #endregion

        #region Metodos
        #endregion
    }
}
