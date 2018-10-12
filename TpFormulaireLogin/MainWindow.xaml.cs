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
using TpFormulaireLogin.DataLayers;
using TpFormulaireLogin.Models;

namespace TpFormulaireLogin
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private User _user = new User();

        public MainWindow()
        {
            InitializeComponent();
            form.DataContext = this._user;
        }

        private void ClickOnLogin(object sender, RoutedEventArgs e)
        {
            Login.BorderBrush = new SolidColorBrush(Colors.Black);
            Password.BorderBrush = new SolidColorBrush(Colors.Black);

            _user.Password = ((PasswordBox)(sender as Button).CommandParameter).Password;
            UserDataLayer _layer = new UserDataLayer();
            decimal? Id = _layer.SearchByLogin(_user.Login);
            if (Id.HasValue)
            {
                if (_layer.PasswordOK((int)Id, _user.Password))
                { 
                    _user = _layer.GetOne((int)Id);
                    MessageBox.Show($"Welcome aboard, {_user.Prenom} {_user.Nom}!");
                }
                else
                {
                    Password.BorderBrush = new SolidColorBrush(Colors.Red);
                    MessageBox.Show("Sorry, wrong password");
                }
            }
            else
            { 
                Login.BorderBrush = new SolidColorBrush(Colors.Red);
                MessageBox.Show("Sorry, wrong login");
            }
            
        }
    }
}
