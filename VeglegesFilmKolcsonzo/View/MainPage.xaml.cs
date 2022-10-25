using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using VeglegesFilmKolcsonzo.Model;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace VeglegesFilmKolcsonzo
{
    public sealed partial class MainPage : Page
    {
        private const int NUMBER_OF_COLLUMNS = 5;
        private int columnIndex = 0;
        private int rowIndex = 0;

        public MainPage()
        {
            this.InitializeComponent();

            LayoutDesign();   
        }

        private void LayoutDesign()
        {
            var movies = Movie.getAllMovies();

            foreach (Movie movie in movies)
            {
                if (isRowFull())
                    addNewRow();

                addMovieButtonToGrid(createButtonForMovie(movie));
            }
        }

        private bool isRowFull()
        {
            return columnIndex == NUMBER_OF_COLLUMNS;
        }

        private void addNewRow()
        {
            MainGrid.RowDefinitions.Add(new RowDefinition());
            rowIndex++;
            columnIndex = 0;
        }

        private Button createButtonForMovie(Movie movie)
        {
            return new Button
            {
                Content = movie.Title,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Height = 100,
                Width = 10000
            };
        }

        private void addMovieButtonToGrid(Button movieButton)
        {
            MainGrid.Children.Add(movieButton);
            Grid.SetRow(movieButton, rowIndex);
            Grid.SetColumn(movieButton, columnIndex);
            columnIndex++;
        }
    }
}
