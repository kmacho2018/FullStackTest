using FullStackTest.Api.Controllers;
using FullStackTest.Data.Models;
using FullStackTest.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System.Net;
using Xunit.Sdk;

namespace FullStackTest.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GetMovies()
        {
            var mockDb = new Mock<IMovieRepository>();
            var logger = new Mock<ILogger<MovieController>>();

            MovieController movieController = new MovieController(logger.Object, mockDb.Object);
            var response = movieController.GetMovies();
            Assert.IsInstanceOfType(response.Result, typeof(OkObjectResult));
        }

        [TestMethod]
        public void GetMovieByName()
        {
            var mockDb = new Mock<IMovieRepository>();
            var logger = new Mock<ILogger<MovieController>>();

            MovieController movieController = new MovieController(logger.Object, mockDb.Object);
            var response = movieController.GetMovie("Avengers");
            Assert.IsInstanceOfType(response.Result, typeof(OkObjectResult));
        }

        [TestMethod]
        public void CreateMovie()
        {
            var mockDb = new Mock<IMovieRepository>();
            var logger = new Mock<ILogger<MovieController>>();

            MovieController movieController = new MovieController(logger.Object, mockDb.Object);
            var response = movieController.CreateMovie(new Movie()
            {
                MovieId = 1,
                Name = "Movie Test",
                Description = "Description movie",
                CreationDate = DateTime.Now,
                Enable = true

            });
            Assert.IsInstanceOfType(response.Result, typeof(OkObjectResult));
        }
    }
}