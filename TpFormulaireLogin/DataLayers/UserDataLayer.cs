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

        public User GetOne(int Id)
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
                            Utilisateur.Id = int.Parse(ReaderUser["Id"].ToString());
                            Utilisateur.Nom = ReaderUser["Nom"].ToString();
                            Utilisateur.Prenom = ReaderUser["Prenom"].ToString();
                            Utilisateur.Login = ReaderUser["Login"].ToString();
                            Utilisateur.Age = int.Parse(ReaderUser["Age"].ToString());
                            Utilisateur.Password = ReaderUser["Password"].ToString();
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

        public bool PasswordOK(int Id, string pwd)
        {
            User user = GetOne(Id);
            return (pwd == user.Password);
        }
    }
}
