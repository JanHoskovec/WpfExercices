using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using TpBinding.Models;

namespace TpBinding
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private PersonData maPersonne = new PersonData();
        private ObservableCollection<PersonData> users = new ObservableCollection<PersonData>();


        public MainWindow()
        {
            InitializeComponent();
            saisie.DataContext = maPersonne;
            //users.Add(new PersonData());
            myList.ItemsSource = users;
        }

        private void CheckNumbersOnly(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Entree(object sender, RoutedEventArgs e)
        {
            users.Add(new PersonData(){
                Nom = maPersonne.Nom,
                Prenom = maPersonne.Prenom,
                Age = maPersonne.Age
            });
        }
    }


}
