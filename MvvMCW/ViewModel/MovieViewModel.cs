using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using MvvMCW.Annotations;
using MvvMCW.Model;
using MvvMCW.Service;
using MvvMCW.Service.Command;

namespace MvvMCW.ViewModel
{
    public class MovieViewModel : INotifyPropertyChanged
    {
        private Movie selectedMovie;
        private int selectedMovieIndex;
        private IFileService _fileService;
        public ObservableCollection<Movie> Movies { get; set; }

        public int SelectedMovieIndex
        {
            get => selectedMovieIndex;
            set => selectedMovieIndex = value;
        }

        public Movie SelectedMovie
        {
            get => selectedMovie;
            set
            {
                selectedMovie = value;
                OnPropertyChanged(nameof(SelectedMovie));
            }
        }

        private RelayCommand _saveCommand;

        public RelayCommand SaveCommand
        {
            get
            {
                return _saveCommand ?? (_saveCommand = new RelayCommand(obj =>
                    _fileService.Save("movies.json", Movies.Select(m => new Movie
                        {
                            Genre = m.Genre,
                            Imdb = m.Imdb,
                            Name = m.Name,
                            Year = m.Year
                        }
                    ).ToList())
                ));
            }
        }

        private RelayCommand _openCommand;

        public RelayCommand OpenCommand
        {
            get
            {
                return _openCommand ?? (_openCommand = new RelayCommand(obj =>
                {
                    var movies = _fileService.Open("movies.json");
                    Movies.Clear();
                    foreach (var m in movies)
                    {
                        Movies.Add(m);
                    }
                }));
            }
        }

        private RelayCommand _addCommand;

      
        public RelayCommand AddCommand
        {
            get
            {
                return _addCommand ?? (_addCommand = new RelayCommand(obj =>
                {
                    Movie movie = new Movie();
                    Movies.Add(movie);
                    SelectedMovie = movie;
                }));
            }
        }
        private RelayCommand _removeCommand;

      
        public RelayCommand RemoveCommand
        {
            get
            {
                return _removeCommand ?? (_removeCommand = new RelayCommand(obj =>
                {
                    Movie movie = obj as Movie;
                    if (movie != null)
                    {
                        Movies.Remove(movie);
                    }
                    SelectedMovie = Movies[0];
                }));
            }
        }
        public MovieViewModel(IFileService fileService)
        {
            _fileService = fileService;

            Movies = new ObservableCollection<Movie>
            {
                new Movie {Name = "Harry Potter", Genre = "Fantasy", Imdb = 9.0f, Year = new DateTime(2018, 10, 10)},
                new Movie {Name = "Kill bill", Genre = "Action", Imdb = 9.0f, Year = new DateTime(2018, 10, 10)},
                new Movie {Name = "Focus", Genre = "Action", Imdb = 9.0f, Year = new DateTime(2018, 10, 10)},
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}