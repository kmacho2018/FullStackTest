using FullStackTest.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullStackTest.Domain.Services
{
    public interface IMovieRepository
    {
        Task<IEnumerable<Movie>> GetMovies();

        Task<Movie> GetMovieById(int movieId);
        Task<Movie> GetMovieByName(string name);


        Task<Movie> AddMovie(Movie movie);

        Task<Movie> UpdateMovie(Movie movie);

        Task<Movie> DeleteMovie(int movieId);
    }
}
