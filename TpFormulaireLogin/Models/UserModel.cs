using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TpFormulaireLogin.Models
{
    public class UserModel : BindableBase
    {
        private string _Name;
        public string Name
        {
            get { return _Name; }
            set { SetProperty(ref _Name, value); }
        }

        private string _Surname;
        public string Surname
        {
            get { return _Surname; }
            set { SetProperty(ref _Surname, value); }
        }

        private int _Age;

        public int Age
        {
            get { return _Age; }
            set { SetProperty(ref _Age, value); }
        }




    }
}
