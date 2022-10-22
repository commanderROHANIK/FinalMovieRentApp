﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;

using VeglegesFilmKolcsonzo.Model;

namespace VeglegesFilmKolcsonzo
{
    public static class DBHelper
    {
        const string serverConnection = "server=127.0.0.1;user id=root;password=;database=filmek";

        public static void getData()
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
                            var movie = new Movie();
                            movie.Show_Id = mySqlReader.GetString(0);
                            movie.Type = mySqlReader.GetString(1);
                            movie.Title = mySqlReader.GetString(2);
                            movie.Director = mySqlReader.GetString(3);
                            movie.Cast = mySqlReader.GetString(4);
                            movie.Country = mySqlReader.GetString(5);
                            movie.Date_Added = mySqlReader.GetString(6);
                            movie.Release_Year = mySqlReader.GetString(7);
                            movie.Rating = mySqlReader.GetString(8);
                            movie.Duration = mySqlReader.GetString(9);
                            movie.Listed_In = mySqlReader.GetString(10);
                            movie.Description = mySqlReader.GetString(11);

                            movies.Add(movie);
                        }
                    }
                }
            }

            Console.WriteLine("kesz");
        }
    }
}