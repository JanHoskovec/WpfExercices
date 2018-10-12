using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TpFormulaireLogin.Models;

namespace TpFormulaireLogin.DataLayers
{
    public class UserDataLayer
    {

        public User GetOne(decimal Id)
        {
            User Utilisateur = new User();

            using (SqlConnection context = new SqlConnection())
            {
                string connectionString = Properties.Settings.Default.chaineDeConnexion;
                context.ConnectionString = connectionString;

                context.Open();

                using (SqlCommand queryUser = context.CreateCommand())
                {
                    queryUser.CommandText = "SELECT Id," +
                                              "Nom," +
                                              "Prenom," +
                                              "Age," +
                                              "Login," +
                                              "Password " +
                                              "FROM [User] " +
                                              "Where Id = " + Id;

                    using (SqlDataReader ReaderUser = queryUser.ExecuteReader())
                    {
                        while (ReaderUser.Read())
                        {
                            Utilisateur.Id = (decimal)ReaderUser["Id"];
                            Utilisateur.Nom = (string)ReaderUser["Nom"];
                            Utilisateur.Prenom = (string)ReaderUser["Prenom"];
                            Utilisateur.Login = (string)ReaderUser["Login"];
                            Utilisateur.Age = (int)ReaderUser["Age"];
                            Utilisateur.Password = (string)ReaderUser["Password"];
                        }
                    }
                }
            }

            return Utilisateur;
        }

        public decimal? SearchByLogin(string login)
        {
            decimal? res = null;

            using (SqlConnection context = new SqlConnection(Properties.Settings.Default.chaineDeConnexion))
            {
                context.Open();
                SqlCommand command = new SqlCommand("Select Id from [User] where Login = '" + login + "'", context);
                res = command.ExecuteScalar() as decimal?; 
            }
            return res;
        }

        public bool PasswordOK(decimal Id, string pwd)
        {
            User user = GetOne(Id);
            return (pwd == user.Password);
        }
    }
}
