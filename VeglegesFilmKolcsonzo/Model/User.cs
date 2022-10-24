using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using VeglegesFilmKolcsonzo.Helper;

namespace VeglegesFilmKolcsonzo.Model
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }

        private const string serverConnection = "server=127.0.0.1;user id=root;password=;database=filmek";

        public static void addUser(string userName, string password)
        {
            using (var sqlConnection = new MySqlConnection(serverConnection))
            {
                using (var sqlQuery = new MySqlCommand($"INSERT INTO `users`(`username`, `password`) VALUES ('{userName}','{MD5Helper.CreateMD5(password)}')", sqlConnection))
                {
                    sqlConnection.Open();
                    sqlQuery.ExecuteReader(CommandBehavior.CloseConnection);
                    sqlConnection.Close();
                }
            }
        }

        public static IEnumerable<User> getAllUsers()
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
                            var user = new User();
                            user.Id = Convert.ToInt32(mySqlReader.GetString(0));
                            user.Name = mySqlReader.GetString(1);
                            user.Password = mySqlReader.GetString(2);

                            users.Add(user);
                        }
                    }
                }
            }

            return users;
        }
    }
}
