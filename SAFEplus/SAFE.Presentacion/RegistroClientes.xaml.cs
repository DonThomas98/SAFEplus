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
            //Separar los nombres y apellidos
            String pNombre, sNombre, pApellido, sApellido;
            if (txtNombres.Text != String.Empty && txtApellidos.Text != String.Empty)
            {
                string[] nombres = txtNombres.Text.Split(' ');
                string[] apellidos = txtApellidos.Text.Split(' ');
                pNombre = nombres[0];
                sNombre = nombres[1];
                pApellido = apellidos[0];
                sApellido = apellidos[1];
            }
            else if (txtNombres.Text == String.Empty && txtApellidos.Text != String.Empty)
            {
                MessageBox.Show("Ingrese los nombres del trabajador");
                txtNombres.Focus();
            }
            else
            {
                MessageBox.Show("Ingrese los apellidos del trabajador");
                txtApellidos.Focus();
            }


        }
    }
}
