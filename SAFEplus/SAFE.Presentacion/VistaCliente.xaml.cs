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
    /// Lógica de interacción para VistaCliente.xaml
    /// </summary>
    public partial class VistaCliente : Window
    {
        Manejadora _mane = new Manejadora();

        public VistaCliente()
        {
            InitializeComponent();
            dtgListaClientes.ItemsSource = _mane.GetClientes().DefaultView;
            cboRutCliente.ItemsSource = _mane.GetRutCliente();
        }

        private void btnVolver_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void cboRutCliente_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string rut = cboRutCliente.SelectedItem.ToString();
            dtgPagosCliente.ItemsSource = _mane.GetPagosCliente(rut).DefaultView;
        }
    }
}
