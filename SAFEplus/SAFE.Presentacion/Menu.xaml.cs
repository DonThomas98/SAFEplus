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
    /// Lógica de interacción para Menu.xaml
    /// </summary>
    public partial class Menu : Window
    {
        public Menu(string nombre)
        {
            InitializeComponent();
            string usuario = nombre;
            lbBienvenido.Content = (lbBienvenido.Content.ToString() + usuario);
        }

        private void btnVolver_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }

        private void btnRegCliente_Click(object sender, RoutedEventArgs e)
        {
            RegistroClientes regCli = new RegistroClientes();
            regCli.Show();
        }

        private void btnVistaCliente_Click(object sender, RoutedEventArgs e)
        {
            VistaCliente vistaCliente = new VistaCliente();
            vistaCliente.Show();
        }

        private void btnContratos_Click(object sender, RoutedEventArgs e)
        {
            Contratos contratos = new Contratos();
            contratos.Show();
        }

        private void btnRegTrabajador_Click(object sender, RoutedEventArgs e)
        {
            RegistroTrabajador regTra = new RegistroTrabajador();
            regTra.Show();
        }

        private void btnVistaTrabajador_Click(object sender, RoutedEventArgs e)
        {
            VistaTrabajador vistaTrabajador = new VistaTrabajador();
            vistaTrabajador.Show();
        }

        private void btnActividades_Click(object sender, RoutedEventArgs e)
        {
            MonitoreoActividades actividades = new MonitoreoActividades();
            actividades.Show();
        }

        private void btnVisitas_Click(object sender, RoutedEventArgs e)
        {
            Visitas visitas = new Visitas();
            visitas.Show();
        }

        private void btnCapacitaciones_Click(object sender, RoutedEventArgs e)
        {
            Capacitaciones capacitaciones = new Capacitaciones();
            capacitaciones.Show();
        }
    }
}