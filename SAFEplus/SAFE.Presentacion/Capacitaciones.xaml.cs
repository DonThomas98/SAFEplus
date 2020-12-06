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
    /// Lógica de interacción para Capacitaciones.xaml
    /// </summary>
    public partial class Capacitaciones : Window
    {
        Manejadora _mane = new Manejadora();
        public Capacitaciones()
        {
            InitializeComponent();
            cboRutTrabajador.ItemsSource = _mane.GetRutTrabajador();
            dtgListaCapacitaciones.ItemsSource = _mane.GetCapacitaciones().DefaultView;
            dtgMateriales.ItemsSource = _mane.GetMateriales().DefaultView;
            cboMateriales.ItemsSource = _mane.GetMateriales2();
            cboCapacitacion.ItemsSource = _mane.GetIdCapacitaciones();
        }

        private void btnVolver_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void cboRutTrabajador_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string rut = cboRutTrabajador.SelectedItem.ToString();
            dtgCapacitaTrabajador.ItemsSource = _mane.GetCapacitacionesTrabajador(rut).DefaultView;
        }

        private void btnRegistrarMaterial_Click(object sender, RoutedEventArgs e)
        {
            if (txtMaterial.Text == String.Empty)
            {
                MessageBox.Show("Describa el material que quiere añadir", "Advertencia");
                txtMaterial.Focus();
            }
            else
            {
                bool result = _mane.SetMaterial(txtMaterial.Text);
                if (result)
                {
                    MessageBox.Show("Material añadido correctamente", "Éxito");
                }
                else
                {
                    MessageBox.Show("Material no se añadió", "Error");
                }
                dtgMateriales.ItemsSource = _mane.GetMateriales().DefaultView;
            }
        }

        private void btnRegistrarCapacitacion_Click(object sender, RoutedEventArgs e)
        {
            if (!dtpFechaCapacitacion.SelectedDate.HasValue)
            {
                MessageBox.Show("Seleccione una fecha para la capacitación");
                dtpFechaCapacitacion.Focus();
            }
            else if (!tpHoraCapacitacion.Value.HasValue)
            {
                MessageBox.Show("Seleccione una hora para la capacitación");
                tpHoraCapacitacion.Focus();
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
                string fecha = dtpFechaCapacitacion.SelectedDate.Value.ToString("dd/MM/yyyy").Replace("-", "/");
                string hora = tpHoraCapacitacion.Text;
                string rutcli = cboRutCliente1.SelectedItem.ToString();
                string ruttra = cboRutTrabajador1.SelectedItem.ToString();

                bool result = _mane.SetCapacitacion(fecha, hora, rutcli, ruttra);
                if (result)
                {
                    MessageBox.Show("Capacitación programada correctamente", "Éxito");
                }
                else
                {
                    MessageBox.Show("Capacitación no se programó", "Error");
                }

                dtgListaCapacitaciones.ItemsSource = _mane.GetCapacitaciones().DefaultView;
            }
        }

        private void btnPrepararCapacitacion_Click(object sender, RoutedEventArgs e)
        {
            if (cboMateriales.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un material");
                cboMateriales.Focus();
            }
            else if (txtCantidad.Text == String.Empty)
            {
                MessageBox.Show("Seleccione la cantidad de materiales");
                txtCantidad.Focus();
            }
            else if (cboCapacitacion.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione una capacitación");
                cboCapacitacion.Focus();
            }
            else
            {
                bool resultado = _mane.SetMaterialCapacitacion(cboMateriales.SelectedItem.ToString(), Int32.Parse(txtCantidad.Text), Int32.Parse(cboCapacitacion.SelectedItem.ToString()));
                if (resultado)
                {
                    MessageBox.Show("Capacitación preparada correctamente", "Éxito");
                }
                else
                {
                    MessageBox.Show("Capacitación no se preparó correctamente", "Error");
                }
            }
        }
    }
}
