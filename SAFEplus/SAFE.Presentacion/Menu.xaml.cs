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
        public Menu()
        {
            InitializeComponent();
            string usuario = "Admin"; //Placeholder, hay que hacer una query para sacar el primer nombre del usuario.

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
            RegistroClientes regCli = new RegistroClientes(this);
            regCli.Show();
            this.Hide();
        }

        private void btnVistaCliente_Click(object sender, RoutedEventArgs e)
        {
            VistaCliente vistaCliente = new VistaCliente(this);
            vistaCliente.Show();
            this.Hide();
        }

        private void btnContratos_Click(object sender, RoutedEventArgs e)
        {
            Contratos contratos = new Contratos(this);
            contratos.Show();
            this.Hide();
        }

        private void btnRegTrabajador_Click(object sender, RoutedEventArgs e)
        {
            RegistroTrabajador regTra = new RegistroTrabajador(this);
            regTra.Show();
            this.Hide();
        }
    }
}