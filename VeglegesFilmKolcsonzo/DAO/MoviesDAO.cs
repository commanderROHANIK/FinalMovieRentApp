using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using VeglegesFilmKolcsonzo.Model;

namespace VeglegesFilmKolcsonzo.DAO
{
    internal class MoviesDAO : IMoviesDAO
    {
        private const string serverConnection = "server=127.0.0.1;user id=root;password=;database=filmek";

        public IEnumerable<Movie> getAllMovies()
        {
            var movies = new List<Movie>();

            using (var sqlConnection = new MySqlConnection(serverConnection))
            {
                using (var sqlQuery = new MySqlCommand("select * from data_2004", sqlConnection))
                {
                    sqlConnection.Open();
                    using (MySqlDataReader mySqlReader = sqlQuery.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        while (mySqlReader.Read())
                        {
                            Debug.WriteLine($"{mySqlReader.GetString(0)}:{mySqlReader.GetString(1)}:{mySqlReader.GetString(2)}:{mySqlReader.GetString(3)}");

                            movies.Add(new Movie()
                            {
                                Show_Id = mySqlReader.GetString(0),
                                Type = mySqlReader.GetString(1),
                                Title = mySqlReader.GetString(2),
                                Director = mySqlReader.GetString(3),
                                Cast = mySqlReader.GetString(4),
                                Country = mySqlReader.GetString(5),
                                Date_Added = mySqlReader.GetString(6),
                                Release_Year = mySqlReader.GetString(7),
                                Rating = mySqlReader.GetString(8),
                                Duration = mySqlReader.GetString(9),
                                Listed_In = mySqlReader.GetString(10),
                                Description = mySqlReader.GetString(11)
                            });
                        }
                    }
                }
            }

            return movies;
        }
    }
}
