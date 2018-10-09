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

namespace Calculator
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Core _core = new Core();

        public MainWindow()
        {
            InitializeComponent();

            Grid _grid = new Grid();
            this.Content = _grid;
        }

        private void ClickOnNumber(object sender, RoutedEventArgs e)
        {
            int.TryParse((sender as Button).Content.ToString(), out int i);
            _core.AddDigit(i); //TODO what to do with the return ?
        }

        private void ClickOnOperator(object sender, RoutedEventArgs e)
        {
            _core.SetOperand((sender as Button).Content.ToString()[0]);
        }

        private void ClickOnClear(object sender, RoutedEventArgs e)
        {

        }

        private void ClickOnEquals(object sender, RoutedEventArgs e)
        {

        }
    }
}
