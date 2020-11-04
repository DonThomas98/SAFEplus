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
    /// Lógica de interacción para RegistroClientes.xaml
    /// </summary>
    public partial class RegistroClientes : Window
    {
        public RegistroClientes()
        {
            InitializeComponent();
        }

        private void btnVolver_Click(object sender, RoutedEventArgs e)
        {
            Menu menu = new Menu();
            menu.Show();
            this.Close();
        }

        private void btnRegistrar_Click(object sender, RoutedEventArgs e)
        {
            //Separar los nombres y apellidos
            String pNombre, sNombre, pApellido, sApellido;
            string[] nombres = txtNombres.Text.Split(' ');
            string[] apellidos = txtApellidos.Text.Split(' ');
            pNombre = nombres[0];
            sNombre = nombres[1];
            pApellido = apellidos[0];
            sApellido = apellidos[1];


        }
    }
}
