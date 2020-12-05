using SAFE.Negocios;
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

namespace SAFE.Presentacion
{
    /// <summary>
    /// Lógica de interacción para RegistroTrabajador.xaml
    /// </summary>
    public partial class RegistroTrabajador : Window
    {
        Manejadora _mane = new Manejadora();
        public RegistroTrabajador()
        {
            InitializeComponent();
        }

        private void btnVolver_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnRegistrar_Click(object sender, RoutedEventArgs e)
        {
            if (txtRut.Text == String.Empty)
            {
                MessageBox.Show("Ingrese el Rut del trabajador");
                txtRut.Focus();
            }
            else if (txtDv.Text == String.Empty)
            {
                MessageBox.Show("Ingrese el dígito verificador del trabajador");
                txtDv.Focus();
            }
            else if (txtEdad.Text == String.Empty)
            {
                MessageBox.Show("Ingrese el edad del trabajador");
                txtEdad.Focus();
            }
            else if (txtNombres.Text == String.Empty)
            {
                MessageBox.Show("Ingrese el nombre del trabajador");
                txtNombres.Focus();
            }
            else if (txtApellidos.Text == String.Empty)
            {
                MessageBox.Show("Ingrese el apellido del trabajador");
                txtApellidos.Focus();
            }
            else if (txtCorreo.Text == String.Empty)
            {
                MessageBox.Show("Ingrese el correo del trabajador");
                txtCorreo.Focus();
            }
            else if (txtSueldo.Text == String.Empty)
            {
                MessageBox.Show("Ingrese el sueldo del trabajador");
                txtDireccion.Focus();
            }
            else if (pwdPassword.Password == String.Empty)
            {
                MessageBox.Show("Ingrese la contraseña del trabajador");
                pwdPassword.Focus();
            }
            else if (pwdConfirmar.Password == String.Empty)
            {
                MessageBox.Show("Confirme la contraseña del trabajador");
                pwdConfirmar.Focus();
            }
            else if (pwdConfirmar.Password != pwdPassword.Password)
            {
                MessageBox.Show("Las contraseñas no son las mismas, inténtelo otra vez.");
                pwdConfirmar.Focus();
            }
            else
            {
                int? admin = chkAdmin.IsChecked.Value ? 1 : 0;
                bool resultado = _mane.SetTrabajador(txtCorreo.Text, pwdPassword.Password, txtNombres.Text, txtApellidos.Text, admin, int.Parse(txtRut.Text), int.Parse(txtSueldo.Text), int.Parse(txtEdad.Text));

                if (resultado)
                {
                    MessageBox.Show("Trabajador registrado con éxito");
                }
                else
                {
                    MessageBox.Show("Fallo");
                }
            }
        }
    }
}
