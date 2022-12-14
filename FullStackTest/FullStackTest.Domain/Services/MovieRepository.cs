using FullStackTest.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullStackTest.Domain.Services
{
    public class MovieRepository : IMovieRepository
    {
        private readonly MovieDBContext movieDBContext;

        public MovieRepository(MovieDBContext movieDBContext)
        {
            this.movieDBContext = movieDBContext;
        }
        public async Task<Movie> AddMovie(Movie movie)
        {
            var result = await movieDBContext.Movie.AddAsync(movie);
            await movieDBContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Movie> DeleteMovie(int movieId)
        {
            var result = await movieDBContext.Movie
                                       .FirstOrDefaultAsync(e => e.MovieId == movieId);
            if (result != null)
            {
                movieDBContext.Movie.Remove(result);
                await movieDBContext.SaveChangesAsync();
                return result;
            }

            return null;
        }

        public async Task<Movie> GetMovieById(int movieId)
        {
            return await movieDBContext.Movie
                           .FirstOrDefaultAsync(e => e.MovieId == movieId);
        }

        public async Task<Movie> GetMovieByName(string name)
        {
            return await movieDBContext.Movie
                                    .FirstOrDefaultAsync(e => e.Name == name);
        }

        public async Task<IEnumerable<Movie>> GetMovies(string sort, int skip, int take, string movieName)
        {
            if (string.IsNullOrEmpty(movieName) || string.IsNullOrWhiteSpace(movieName))
            {
                if (sort == "Asc")
                {
                    return await movieDBContext.Movie.Skip(skip).Take(take).OrderBy(x => x.Name).ToListAsync();
                }
                else
                {
                    return await movieDBContext.Movie.Skip(skip).Take(take).OrderByDescending(x => x.Name).ToListAsync();
                }
            }
            else
            {
                if (sort == "Asc")
                {
                    return await movieDBContext.Movie.Where(x=>x.Name.Contains(movieName)).Skip(skip).Take(take).OrderBy(x => x.Name).ToListAsync();
                }
                else
                {
                    return await movieDBContext.Movie.Where(x => x.Name.Contains(movieName)).Skip(skip).Take(take).OrderByDescending(x => x.Name).ToListAsync();
                }
            }

        }

        public async Task<Movie> UpdateMovie(Movie movie)
        {
            var result = await movieDBContext.Movie
                            .FirstOrDefaultAsync(e => e.MovieId == movie.MovieId);

            if (result != null)
            {
                result.Name = movie.Name;
                result.Description = movie.Description;
                result.Enable = movie.Enable;
                result.UpdateDate = DateTime.Now;

                await movieDBContext.SaveChangesAsync();

                return result;
            }

            return null;
        }
    }
}
