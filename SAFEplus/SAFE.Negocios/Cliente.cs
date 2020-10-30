using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAFE.Negocios
{
    class Cliente
    {
        #region Campos
        private String _cliRut;
        private char _cliDv;
        private String _cliPNombre;
        private String _cliSNombre;
        private String _cliPApellido;
        private String _cliSApellido;
        private String _cliCorreo;
        private int _cliEdad;
        private String _cliDireccion;
        private long _cliTelefono;
        private long _cliCelular;
        #endregion

        #region Propiedades
        public string CliRut { get => _cliRut; set => _cliRut = value; }
        public char CliDv { get => _cliDv; set => _cliDv = value; }
        public string CliPNombre { get => _cliPNombre; set => _cliPNombre = value; }
        public string CliSNombre { get => _cliSNombre; set => _cliSNombre = value; }
        public string CliPApellido { get => _cliPApellido; set => _cliPApellido = value; }
        public string CliSApellido { get => _cliSApellido; set => _cliSApellido = value; }
        public string CliCorreo { get => _cliCorreo; set => _cliCorreo = value; }
        public int CliEdad { get => _cliEdad; set => _cliEdad = value; }
        public string CliDireccion { get => _cliDireccion; set => _cliDireccion = value; }
        public long CliTelefono { get => _cliTelefono; set => _cliTelefono = value; }
        public long CliCelular { get => _cliCelular; set => _cliCelular = value; }
        #endregion

        #region Constructor

        public Cliente(string cliRut, char cliDv, string cliPNombre, string cliSNombre, string cliPApellido, string cliSApellido, string cliCorreo, int cliEdad, string cliDireccion, long cliTelefono, long cliCelular)
        {
            _cliRut = cliRut;
            _cliDv = cliDv;
            _cliPNombre = cliPNombre;
            _cliSNombre = cliSNombre;
            _cliPApellido = cliPApellido;
            _cliSApellido = cliSApellido;
            _cliCorreo = cliCorreo;
            _cliEdad = cliEdad;
            _cliDireccion = cliDireccion;
            _cliTelefono = cliTelefono;
            _cliCelular = cliCelular;
        }

        public Cliente()
        {
            _cliRut = string.Empty;
            _cliDv = '0';
            _cliPNombre = string.Empty;
            _cliSNombre = string.Empty;
            _cliPApellido = string.Empty;
            _cliSApellido = string.Empty;
            _cliCorreo = string.Empty;
            _cliEdad = 0;
            _cliDireccion = string.Empty;
            _cliTelefono = 0;
            _cliCelular = 0;
        }
        #endregion

        #region Metodos
        #endregion
    }
}
