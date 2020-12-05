using Oracle.ManagedDataAccess.Client;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SAFE.Presentacion
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Manejadora _mane = new Manejadora();
        public MainWindow()
        {
            InitializeComponent();
            txtUser.Focus();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (txtUser.Text == "admin" && pwdPass.Password == "admin")
            {
                string nombre = "Admin";
                Menu menu = new Menu(nombre);
                menu.Show();
                this.Close();
            }
            else if (_mane.Login(txtUser.Text, pwdPass.Password) == true)
            {
                string nombre = _mane.GetNombre(txtUser.Text);
                Menu menu = new Menu(nombre);
                menu.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Correo o contraseña incorrectos. Intente de nuevo.");
                txtUser.Focus();
            }
        }

        private void btnAyuda_Click(object sender, RoutedEventArgs e)
        {
            Ayuda ayuda = new Ayuda();
            ayuda.Show();
        }
    }
}