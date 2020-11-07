using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using SAFE.Negocios;
using Oracle.ManagedDataAccess.Client;

namespace SAFE.Presentacion
{
    /// <summary>
    /// Lógica de interacción para RegistroClientes.xaml
    /// </summary>
    public partial class RegistroClientes : Window
    {
        Manejadora _mane = new Manejadora();

        public RegistroClientes()
        {
            InitializeComponent();
            OracleConnection conn = _mane.ConexionDB();
        }

        private void btnVolver_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnRegistrar_Click(object sender, RoutedEventArgs e)
        {
            if (txtRut.Text == String.Empty)
            {
                MessageBox.Show("Ingrese el Rut del cliente");
                txtRut.Focus();
            }
            else if (txtDv.Text == String.Empty)
            {
                MessageBox.Show("Ingrese el dígito verificador del cliente");
                txtDv.Focus();
            }
            else if (txtEdad.Text == String.Empty)
            {
                MessageBox.Show("Ingrese el edad del cliente");
                txtEdad.Focus();
            }
            else if (txtNombres.Text == String.Empty)
            {
                MessageBox.Show("Ingrese el nombre del cliente");
                txtNombres.Focus();
            }
            else if (txtApellidos.Text == String.Empty)
            {
                MessageBox.Show("Ingrese el apellido del cliente");
                txtApellidos.Focus();
            }
            else if (txtCorreo.Text == String.Empty)
            {
                MessageBox.Show("Ingrese el correo del cliente");
                txtCorreo.Focus();
            }
            else if (txtDireccion.Text == String.Empty)
            {
                MessageBox.Show("Ingrese el direccion del cliente");
                txtDireccion.Focus();
            }
            else if (pwdPassword.Password == String.Empty)
            {
                MessageBox.Show("Ingrese la contraseña del cliente");
                pwdPassword.Focus();
            }
            else if (pwdConfirmar.Password == String.Empty)
            {
                MessageBox.Show("Confirme la contraseña del cliente");
                pwdConfirmar.Focus();
            }
            else if (pwdConfirmar.Password != pwdPassword.Password)
            {
                MessageBox.Show("Las contraseñas no son las mismas, inténtelo otra vez.");
                pwdConfirmar.Focus();
            }
            
            _mane.SetCliente(txtRut.Text, txtDv.Text, txtEdad.Text, txtNombres.Text, txtApellidos.Text, txtCorreo.Text, txtDireccion.Text, txtTelefono.Text, txtCelular.Text, pwdPassword.Password);

        }
    }
}
