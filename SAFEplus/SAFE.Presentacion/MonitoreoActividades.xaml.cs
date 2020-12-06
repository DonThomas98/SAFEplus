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
    /// Lógica de interacción para MonitoreoActividades.xaml
    /// </summary>
    public partial class MonitoreoActividades : Window
    {
        Manejadora _mane = new Manejadora();
        public MonitoreoActividades()
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
            cboMes.ItemsSource = meses;
            cboAño.ItemsSource = años;
            dtgAccidentes.ItemsSource = _mane.GetAsesoriasAccidente().DefaultView;
            dtgFiscalizaciones.ItemsSource = _mane.GetAsesoriasFiscalizacion().DefaultView;
        }

        private void btnVolver_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void cboRutCliente_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            dtgAccidentesCliente.ItemsSource = _mane.GetAsesoriasAccidente().DefaultView;
            
        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            string mesaño = cboMes.SelectedItem.ToString() + "/" + cboAño.SelectedItem.ToString();
            lbAccidentabilidad.Content = _mane.GetAccidentabilidad(mesaño);
            dtgAccidentesCliente.ItemsSource = _mane.GetAsesoriasAccidenteFecha(mesaño).DefaultView;
        }
    }
}
