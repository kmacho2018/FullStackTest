using FluentValidation.Results;
using FullStackTest.Data.Models;
using FullStackTest.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace FullStackTest.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewRepository reviewRepository;
        private readonly ILogger<ReviewController> _logger;

        public ReviewController(ILogger<ReviewController> logger, IReviewRepository reviewRepository)
        {
            this.reviewRepository = reviewRepository;
            _logger = logger;
        }

        [Route("AddReview")]
        [HttpPost]
        public async Task<ActionResult> AddReview(Review review)
        {
            try
            {
                if (review == null)
                {
                    return BadRequest();
                }
                _logger.LogInformation("Checking if the review is associated with any record.");

                ReviewValidator validator = new ReviewValidator();
                ValidationResult results = validator.Validate(review);

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
                    var createdReview = await reviewRepository.AddReview(review);

                    return CreatedAtAction(nameof(GetReviewsByMovieId), new { id = createdReview.MovieId },
                        createdReview);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [Route("GetReviewsByMovie")]
        [HttpGet]
        public async Task<ActionResult> GetReviewsByMovieId(int movieId)
        {
            try
            {
                _logger.LogInformation("Start to GetMovie");
                return Ok(await reviewRepository.GetReviewsByMovieId(movieId));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }
    }
}
