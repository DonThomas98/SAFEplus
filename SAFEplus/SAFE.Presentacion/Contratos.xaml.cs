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
        private Menu _menu;

        public Contratos(Menu menu)
        {
            InitializeComponent();
            _menu = menu; //Hereda la ventana menú para que no crear ventanas nuevas y queden ventanas ocultas abiertas en memoria
        }

        private void btnVolver_Click(object sender, RoutedEventArgs e)
        {
            _menu.Show();
            this.Close();
        }
    }
}
