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

namespace HelloWorld
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Ne marchait pas bien
            //grid1.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(5, GridUnitType.Star) });
            //grid1.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(3, GridUnitType.Star) });
            //grid1.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(2, GridUnitType.Star) });
            //grid1.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(3, GridUnitType.Star) });
            //grid1.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(2, GridUnitType.Star) });

            //var header = new TextBlock()
            //{
            //    HorizontalAlignment = HorizontalAlignment.Center,
            //    VerticalAlignment = VerticalAlignment.Center,
            //    FontSize = 36,
            //    FontWeight = FontWeights.Bold,
            //    TextWrapping = TextWrapping.Wrap,
            //    Text = "Bonjour !"
            //};
            //LinearGradientBrush myBrush = new LinearGradientBrush();
            //myBrush.GradientStops.Add(new GradientStop() { Color = Colors.Blue, Offset = 0});
            //myBrush.GradientStops.Add(new GradientStop() { Color = Colors.Yellow, Offset = 0.5 });
            //myBrush.GradientStops.Add(new GradientStop() { Color = Colors.Red, Offset = 1 });
            //header.Foreground = myBrush;

            //Grid.SetRow(header, 0);
            //Grid.SetColumn(header, 1);

            var header2 = new TextBlock()
            {
                Text = "Bienvenu dans l'application",
                FontWeight = FontWeights.DemiBold,
                VerticalAlignment = VerticalAlignment.Bottom,
                HorizontalAlignment = HorizontalAlignment.Center
            };
            Thickness margin = header2.Margin;
            margin.Bottom = 10;
            header2.Margin = margin;
            Grid.SetRow(header2, 0);
            Grid.SetColumn(header2, 1);

            //grid1.Children.Add(header);
            grid1.Children.Add(header2);
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Thank you for clicking me :)");
        }
    }
}
