using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using MySql.Data.MySqlClient;

namespace VeglegesFilmKolcsonzo.Model
{
    public class Movie
    {
        public string Show_Id { get; set; }
        public string Type { get; set; }
        public string Title { get; set; }
        public string Director { get; set; }
        public string Cast { get; set; }
        public string Country { get; set; }
        public string Date_Added { get; set; }
        public string Release_Year { get; set; }
        public string Rating { get; set; }
        public string Duration { get; set; }
        public string Listed_In { get; set; }
        public string Description { get; set; }

    }
}
