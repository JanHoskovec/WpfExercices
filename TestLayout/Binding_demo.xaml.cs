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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TestLayout
{
    /// <summary>
    /// Logique d'interaction pour Binding_demo.xaml
    /// </summary>
    public partial class Binding_demo : Page
    {
        public Binding_demo()
        {
            InitializeComponent();
        }

        private void SetToSmall(object sender, RoutedEventArgs e)
        {
            this.lblSampleText.FontSize = 5.0;
        }

        private void SetToNormal(object sender, RoutedEventArgs e)
        {
            this.lblSampleText.FontSize = 10.0;
        }

        private void SetToLarge(object sender, RoutedEventArgs e)
        {
            this.lblSampleText.FontSize = 20.0;
        }
    }
}
