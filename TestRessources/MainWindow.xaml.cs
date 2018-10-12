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

namespace TestRessources
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            // If TileBrush is not set, you can create it like that
            //this.Resources["TileBrush"] = new SolidColorBrush(Colors.Blue);
            InitializeComponent();
        }

        private void Click(object sender, RoutedEventArgs e)
        {
            Button cmd = (Button)sender;
            ImageBrush brush = (ImageBrush)cmd.TryFindResource("TileBrush");
            
        }
    }
}
