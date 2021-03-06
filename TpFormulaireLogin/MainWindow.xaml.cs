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
using TpFormulaireLogin.DataLayers;
using TpFormulaireLogin.Models;
using TpFormulaireLogin.ViewModel;

namespace TpFormulaireLogin
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private User _user = new User();
        private UserViewModel UserData = new UserViewModel();


        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = UserData;  
        }
        
    }
}
