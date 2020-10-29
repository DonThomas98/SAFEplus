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
    /// Lógica de interacción para mantenedorBase.xaml
    /// </summary>
    public partial class mantenedorBase : Window
    {
        public mantenedorBase()
        {
            InitializeComponent();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            //Este es la accion click del boton salir del menu mantenedor (ᵔᴥᵔ)
            this.Close();
        }

        private void txtConsultaClientes_Click(object sender, RoutedEventArgs e)
        {
            //Este es la accion click del boton consulta de clientes para que muestre el datagrid oculto antes (ᵔᴥᵔ)
            dtgClientes.Visibility = Visibility.Visible;
        }

        private void txtCrearClientes_Click(object sender, RoutedEventArgs e)
        {
            //Este es la accion click del boton crear clientes , cierra esta ventana y abre la ventana crear clientes (ᵔᴥᵔ)
            crearClientes crearClientes = new crearClientes();
            crearClientes.Show();
            this.Close();
        }

        private void txtConsultaTrabajadores_Click(object sender, RoutedEventArgs e)
        {
            //Este es la accion click del boton consulta de trabajadores para que muestre el datagrid oculto antes (ᵔᴥᵔ)
            
            dtgTrabajadores.Visibility = Visibility.Visible;



        }

        private void txtRegistroTrabajadores_Click(object sender, RoutedEventArgs e)
        {
            //Este es la accion click del boton crear trabajadores , cierra esta ventana y abre la ventana crear trabajadores (ᵔᴥᵔ)
            crearTrabajadores crearTrabajadores = new crearTrabajadores();
            crearTrabajadores.Show();
            this.Close();

        }
    }
}
