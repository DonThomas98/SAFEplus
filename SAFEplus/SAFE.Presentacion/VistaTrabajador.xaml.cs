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
    /// Lógica de interacción para VistaTrabajador.xaml
    /// </summary>
    public partial class VistaTrabajador : Window
    {
        Manejadora _mane = new Manejadora();
        public VistaTrabajador()
        {
            InitializeComponent();
            var meses = new List<string>(){
                "01",
                "02",
                "03",
                "04",
                "05",
                "06",
                "07",
                "08",
                "09",
                "10",
                "11",
                "12"
            };

            var años = new List<string>(){
                "2020",
                "2021",
                "2022",
                "2023",
                "2024",
                "2025"
            };

            dtgListaTrabajadores.ItemsSource = _mane.GetTrabajadores().DefaultView;
            cboRutTrabajador.ItemsSource = _mane.GetRutTrabajador();
            cboMes.ItemsSource = meses;
            cboAño.ItemsSource = años;
        }

        private void btnVolver_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            if (cboRutTrabajador.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un trabajador");
                cboRutTrabajador.Focus();
            }
            else if (cboMes.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un mes");
                cboMes.Focus();
            }
            else if (cboAño.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un año");
                cboAño.Focus();
            }
            else
            {
                //MessageBox.Show(cboRutTrabajador.SelectedItem.ToString() + "\n" + cboMes.SelectedItem.ToString() + "\n" + cboAño.SelectedItem.ToString());

                string rut = cboRutTrabajador.SelectedItem.ToString();
                string mes = cboMes.SelectedItem.ToString();
                string año = cboAño.SelectedItem.ToString();
                dtgCargaLabTrabajador.ItemsSource = _mane.GetCargaLabTrabajador(mes, año, rut).DefaultView;
            }
        }
    }
}
