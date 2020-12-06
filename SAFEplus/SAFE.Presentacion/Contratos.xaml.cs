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
    /// Lógica de interacción para Contratos.xaml
    /// </summary>
    public partial class Contratos : Window
    {
        Manejadora _mane = new Manejadora();
        public Contratos()
        {
            InitializeComponent();
            cboRutCliente.ItemsSource = _mane.GetRutCliente();
            dtgContratos.ItemsSource = _mane.GetContratos().DefaultView;
        }

        private void btnVolver_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void cboRutCliente_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            dtgListaContratosCliente.ItemsSource = _mane.GetContratosCliente(cboRutCliente.SelectedItem.ToString()).DefaultView;
        }
    }
}
