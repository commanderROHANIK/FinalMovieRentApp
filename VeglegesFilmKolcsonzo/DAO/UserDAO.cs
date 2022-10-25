using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using VeglegesFilmKolcsonzo.Helper;
using VeglegesFilmKolcsonzo.Model;

namespace VeglegesFilmKolcsonzo.DAO
{
    internal class UserDAO : IUserDAO
    {

        private const string serverConnection = "server=127.0.0.1;user id=root;password=;database=filmek";

        public void addUser(string userName, string password)
        {
            using (var sqlConnection = new MySqlConnection(serverConnection))
            {
                using (var sqlQuery = new MySqlCommand($"INSERT INTO `users`(`username`, `password`) VALUES ('{userName}','{MD5Helper.CreateMD5(password)}')", sqlConnection))
                {
                    sqlConnection.Open();
                    sqlQuery.ExecuteReader(CommandBehavior.CloseConnection);
                }
            }
        }

        public IEnumerable<User> getAllUsers()
        {
            var users = new List<User>();

            using (var sqlConnection = new MySqlConnection(serverConnection))
            {
                using (var sqlQuery = new MySqlCommand("select * from users", sqlConnection))
                {
                    sqlConnection.Open();
                    using (MySqlDataReader mySqlReader = sqlQuery.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        while (mySqlReader.Read())
                        {
                            users.Add(new User()
                            {
                                Id = Convert.ToInt32(mySqlReader.GetString(0)),
                                Name = mySqlReader.GetString(1),
                                Password = mySqlReader.GetString(2)
                            });
                        }
                    }
                }
            }

            return users;
        }
    }
}
