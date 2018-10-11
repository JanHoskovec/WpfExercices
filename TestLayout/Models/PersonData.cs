using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestLayout.Models
{
    public class PersonData
    {
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public int Age { get; set; }

        public string MyString { get { return Nom + " " + Prenom + ", aged " + Age; } }

        public PersonData()
        {
            Nom = "Hoskovec";
            Prenom = "Jan";
            Age = 29;
        }
    }
}
