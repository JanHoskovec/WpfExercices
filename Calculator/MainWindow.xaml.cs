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
        }

        private void ClickOnNumber(object sender, RoutedEventArgs e)
        {
            int.TryParse((sender as Button).Content.ToString(), out int i);
            List<string> res = _core.AddDigit(i);
            text_first.Text = res[0];
            text_second.Text = res[1];
        }

        private void ClickOnOperator(object sender, RoutedEventArgs e)
        {
            List<string> res = _core.SetOperator((sender as Button).Content.ToString()[0]);
            text_first.Text = res[0];
            text_operand.Text = res[1];
            text_second.Text = res[2];
        }

        private void ClickOnClear(object sender, RoutedEventArgs e)
        {
            _core.Clear();
            text_first.Text = "";
            text_second.Text = "";
            text_operand.Text = "";
            text_result.Text = "";
        }

        private void ClickOnEquals(object sender, RoutedEventArgs e)
        {
            try
            { 
                text_result.Text = _core.Compute();
            }
            catch (DivideByZeroException)
            {

            }
        }

        private void ClickOnPoint(object sender, RoutedEventArgs e)
        {
            List<string> res = _core.Point();
            text_first.Text = res[0];
            text_second.Text = res[1];
        }

        private void ClickOnSign(object sender, RoutedEventArgs e)
        {
            List<string> res = _core.ChangeSign();
            text_first.Text = res[0];
            text_second.Text = res[1];
        }

        private void ClickOnPercent(object sender, RoutedEventArgs e)
        {
            List<string> res = _core.Percent();
            text_first.Text = res[0];
            text_second.Text = res[1];
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9)
            {
                ClickOnNumber(new Button { Content = (e.Key - Key.NumPad0).ToString() }, null);
            }
            else
            {
                switch(e.Key)
                {
                    case (Key.Add):
                        ClickOnOperator(new Button { Content = "+" }, null);
                        break;
                    case (Key.Subtract):
                        ClickOnOperator(new Button { Content = "-" }, null);
                        break;
                    case (Key.Multiply):
                        ClickOnOperator(new Button { Content = "*" }, null);
                        break;
                    case (Key.Divide):
                        ClickOnOperator(new Button { Content = "/" }, null);
                        break;
                    case (Key.Enter):
                        ClickOnEquals(null, null);
                        break;
                    case (Key.Decimal):
                        ClickOnPoint(null, null);
                        break;
                    case (Key.Delete):
                        ClickOnClear(null, null);
                        break;
                }
            }
        }
    }
}
