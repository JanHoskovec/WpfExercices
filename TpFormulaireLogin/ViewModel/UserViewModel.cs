using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using TpFormulaireLogin.DataLayers;
using TpFormulaireLogin.Models;

namespace TpFormulaireLogin.ViewModel
{
    public class UserViewModel : BindableBase
    {
        private User _user = new User();
        public User UserModelData { get { return _user; } set { SetProperty(ref _user, value); } }

        public DelegateCommand<PasswordBox> Login { get; }

        public UserViewModel()
        {
            Login = new DelegateCommand<PasswordBox>(DoLogin);
        }
        
        private void DoLogin(PasswordBox box)
        {
            _user.Password = box.Password;
            UserDataLayer _layer = new UserDataLayer();
            decimal? Id = _layer.SearchByLogin(_user.Login);
            if (Id.HasValue)
            {
                if (_layer.PasswordOK(Id.Value, _user.Password))
                {
                    _user = _layer.GetOne(Id.Value);
                    MessageBox.Show($"Welcome aboard, {_user.Prenom} {_user.Nom}!");
                }
                else
                {
                    MessageBox.Show("Sorry, wrong password");
                }
            }
            else
            {
                MessageBox.Show("Sorry, wrong login");
            }

        }
    }
}
