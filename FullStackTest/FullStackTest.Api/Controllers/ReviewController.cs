using FullStackTest.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace FullStackTest.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IMovieRepository movieRepository;
        private readonly ILogger<ReviewController> _logger;

        public ReviewController(ILogger<ReviewController> logger, IMovieRepository movieRepository)
        {
            this.movieRepository = movieRepository;
            _logger = logger;
        }

        [Route("AddReview")]
        [HttpPost]
        public async Task<ActionResult> AddReview()
        { return null; }

        [Route("GetReviewsByMovie")]
        [HttpGet]
        public async Task<ActionResult> GetReviewsByMovie()
        { return null; }
    }
}
