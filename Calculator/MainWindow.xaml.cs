﻿using System;
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
            text_operand.Text = _core.SetOperand((sender as Button).Content.ToString()[0]).ToString();
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
    }
}