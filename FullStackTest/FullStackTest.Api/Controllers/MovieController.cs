using FluentValidation.Results;
using FullStackTest.Data.Models;
using FullStackTest.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using NuGet.ContentModel;

namespace FullStackTest.Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieRepository movieRepository;
        private readonly ILogger<MovieController> _logger;

        public MovieController(ILogger<MovieController> logger, IMovieRepository movieRepository)
        {
            this.movieRepository = movieRepository;
            _logger = logger;
        }
        [Route("GetAllMovies")]
        [HttpGet]
        public async Task<ActionResult> GetMovies()
        {
            try
            {
                _logger.LogInformation("Start to GetMovies");
                return Ok(await movieRepository.GetMovies());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [Route("GetMovieByName")]
        [HttpGet]
        public async Task<ActionResult> GetMovie(string name)
        {
            try
            {
                _logger.LogInformation("Start to GetMovie");
                return Ok(await movieRepository.GetMovieByName(name));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [Route("DisableMovie")]
        [HttpPut]
        public async Task<ActionResult<Movie>> DisableMovie(int movieId)
        {
            try
            {
         

                var MovieToUpdate = await movieRepository.GetMovieById(movieId);

                if (MovieToUpdate == null)
                {
                    _logger.LogInformation($"Error Updating Movie. -> Movie with Id = {movieId} not found");

                    return NotFound($"Movie with movieId = {movieId} not found");
                }

                MovieValidator validator = new MovieValidator();
                MovieToUpdate.Enable = false;
                ValidationResult results = validator.Validate(MovieToUpdate);

                if (!results.IsValid)
                {
                    foreach (var failure in results.Errors)
                    {
                        Console.WriteLine("Property " + failure.PropertyName + " failed validation. Error was: " + failure.ErrorMessage);
                    }
                    return BadRequest(string.Join("", results.Errors));
                }
                else
                {
                    _logger.LogInformation($"Updating Movie...");

                    return await movieRepository.UpdateMovie(MovieToUpdate);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating data");
            }
        }


        [Route("CreateMovie")]
        [HttpPost]
        public async Task<ActionResult<Movie>> CreateMovie(Movie movie)
        {
            try
            {
                if (movie == null)
                {
                    return BadRequest();
                }
                _logger.LogInformation("Checking if the movie is associated with any record.");

                MovieValidator validator = new MovieValidator();
                ValidationResult results = validator.Validate(movie);

                if (!results.IsValid)
                {
                    foreach (var failure in results.Errors)
                    {
                        Console.WriteLine("Property " + failure.PropertyName + " failed validation. Error was: " + failure.ErrorMessage);
                    }
                    _logger.LogInformation("Some validation errors have been generated. " + string.Join("", results.Errors));

                    return BadRequest(string.Join("", results.Errors));
                }
                else
                {
                    _logger.LogInformation("Creating new Movie.");
                    var createdMovie = await movieRepository.AddMovie(movie);

                    return CreatedAtAction(nameof(GetMovies), new { id = createdMovie.MovieId },
                        createdMovie);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }
    }
}
