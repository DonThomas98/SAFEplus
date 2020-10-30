using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAFE.Negocios
{
    class Trabajador
    {
        #region Campos
        private String _traRut;
        private char _traDv;
        private String _traPNombre;
        private String _traSNombre;
        private String _traPApellido;
        private String _traSApellido;
        private String _traCorreo;
        private int _traEdad;
        private String _traDireccion;
        private long _traTelefono;
        private long _traCelular;
        private Boolean _traHabilitado;
        private long _traSueldo;
        private String _traContraseña;
        private Boolean _traSuperuser;
        private int _traIdCargo;
        #endregion

        #region Propiedades
        public string TraRut { get => _traRut; set => _traRut = value; }
        public char TraDv { get => _traDv; set => _traDv = value; }
        public string TraPNombre { get => _traPNombre; set => _traPNombre = value; }
        public string TraSNombre { get => _traSNombre; set => _traSNombre = value; }
        public string TraPApellido { get => _traPApellido; set => _traPApellido = value; }
        public string TraSApellido { get => _traSApellido; set => _traSApellido = value; }
        public string TraCorreo { get => _traCorreo; set => _traCorreo = value; }
        public int TraEdad { get => _traEdad; set => _traEdad = value; }
        public string TraDireccion { get => _traDireccion; set => _traDireccion = value; }
        public long TraTelefono { get => _traTelefono; set => _traTelefono = value; }
        public long TraCelular { get => _traCelular; set => _traCelular = value; }
        public bool TraHabilitado { get => _traHabilitado; set => _traHabilitado = value; }
        public long TraSueldo { get => _traSueldo; set => _traSueldo = value; }
        public string TraContraseña { get => _traContraseña; set => _traContraseña = value; }
        public bool TraSuperuser { get => _traSuperuser; set => _traSuperuser = value; }
        public int TraIdCargo { get => _traIdCargo; set => _traIdCargo = value; }
        #endregion

        #region Constructor

        public Trabajador(string cliRut, char cliDv, string cliPNombre, string cliSNombre, string cliPApellido, string cliSApellido, string cliCorreo, int cliEdad, string cliDireccion, long cliTelefono, long cliCelular, bool traHabilitado, long traSueldo, string traContraseña, bool traSuperuser, int traIdCargo)
        {
            _traRut = cliRut;
            _traDv = cliDv;
            _traPNombre = cliPNombre;
            _traSNombre = cliSNombre;
            _traPApellido = cliPApellido;
            _traSApellido = cliSApellido;
            _traCorreo = cliCorreo;
            _traEdad = cliEdad;
            _traDireccion = cliDireccion;
            _traTelefono = cliTelefono;
            _traCelular = cliCelular;
            _traHabilitado = traHabilitado;
            _traSueldo = traSueldo;
            _traContraseña = traContraseña;
            _traSuperuser = traSuperuser;
            _traIdCargo = traIdCargo;
        }

        public Trabajador()
        {
            _traRut = string.Empty;
            _traDv = '0';
            _traPNombre = string.Empty;
            _traSNombre = string.Empty;
            _traPApellido = string.Empty;
            _traSApellido = string.Empty;
            _traCorreo = string.Empty;
            _traEdad = 0;
            _traDireccion = string.Empty;
            _traTelefono = 0;
            _traCelular = 0;
            _traHabilitado = false;
            _traSueldo = 0;
            _traContraseña = string.Empty;
            _traSuperuser = false;
            _traIdCargo = 0;
        }
        #endregion

        #region Metodos
        #endregion
    }
}
