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
    /// Lógica de interacción para Visitas.xaml
    /// </summary>
    public partial class Visitas : Window
    {
        Manejadora _mane = new Manejadora();
        public Visitas()
        {
            InitializeComponent();
            cboRutCliente.ItemsSource = _mane.GetRutCliente();
            cboRutTrabajador.ItemsSource = _mane.GetRutTrabajador();
            
            var motivos = new List<string>(){
                "Rutinaria",
                "Especial"
            };

            cboMotivo.ItemsSource = motivos;
            cboRutCliente1.ItemsSource = _mane.GetRutCliente();
            cboRutTrabajador1.ItemsSource = _mane.GetRutTrabajador();
        }

        private void btnVolver_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void cboRutCliente_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string rut = cboRutCliente.SelectedItem.ToString();
            dtgVisitas.ItemsSource = _mane.GetVisitas(0, rut).DefaultView;
        }

        private void cboRutTrabajador_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string rut = cboRutTrabajador.SelectedItem.ToString();
            dtgVisitas.ItemsSource = _mane.GetVisitas(1, rut).DefaultView;
        }

        private void btnRegistrar_Click(object sender, RoutedEventArgs e)
        {
            if (cboMotivo.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un motivo para la visita");
                cboMotivo.Focus();
            }
            else if (!dtpFechaVisita.SelectedDate.HasValue)
            {
                MessageBox.Show("Seleccione una fecha para la visita");
                dtpFechaVisita.Focus();
            }
            else if (cboRutCliente1.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione el RUT del cliente");
                cboRutCliente1.Focus();
            }
            else if (cboRutTrabajador1.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione el RUT del trabajador");
                cboRutTrabajador1.Focus();
            }
            else
            {
                string motivo = cboMotivo.SelectedItem.ToString();
                string fecha = dtpFechaVisita.SelectedDate.Value.ToString("dd/MM/yyyy").Replace("-", "/");
                string rutcli = cboRutCliente1.SelectedItem.ToString();
                string ruttra = cboRutTrabajador1.SelectedItem.ToString();

                bool result = _mane.SetVisita(motivo, fecha, rutcli, ruttra);
                if (result)
                {
                    MessageBox.Show("Visita programada correctamente", "Éxito");
                }
                else
                {
                    MessageBox.Show("Visita no se programó", "Error");
                }
                
            }
            
        }
    }
}
