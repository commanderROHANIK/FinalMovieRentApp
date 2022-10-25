using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeglegesFilmKolcsonzo.Model;

namespace VeglegesFilmKolcsonzo.DAO
{
    internal interface IMoviesDAO
    {
        IEnumerable<Movie> getAllMovies();
    }
}
