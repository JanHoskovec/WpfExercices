using IntroMVVM.Models;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroMVVM.ViewModel
{
    public class UserViewModel : BindableBase
    {
        private DelegateCommand _DemoCommand;
        public DelegateCommand DemoCommand
        {
            get { return _DemoCommand; }
        }

        private UserModel _UserModelData;
        public UserModel UserModelData
        {
            get { return _UserModelData; }
            set { SetProperty(ref _UserModelData, value); }
        }

        public UserViewModel()
        {
            _UserModelData = new UserModel();
            _UserModelData.Name = "Jan";
            _UserModelData.Surname = "Hoskovec";
            _UserModelData.Age = 29;

            _DemoCommand = new DelegateCommand(DoAction, canDoAction); // Possible d'appeler juste DoAction
        }

        private bool canDoAction()
        { 
            return true;
        }

        private void DoAction()
        {
            _UserModelData.Surname = "Von Hostkowitz";
        }


    }
}
