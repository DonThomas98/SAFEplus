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
    /// Lógica de interacción para crearTrabajadores.xaml
    /// </summary>
    public partial class crearTrabajadores : Window
    {
        public crearTrabajadores()
        {
            InitializeComponent();
        }

        private void btnRegistrarTrabajador_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Trabajador registrado exitosamente");
        }

        private void btnVolver_Click(object sender, RoutedEventArgs e)
        {
            //Este boton volver devuelve a la ventana anterior
            mantenedorBase mantenedorBase = new mantenedorBase();
            mantenedorBase.Show();
            this.Close();
        }
    }
}
