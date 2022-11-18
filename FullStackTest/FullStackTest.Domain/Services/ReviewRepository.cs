using FullStackTest.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullStackTest.Domain.Services
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly MovieDBContext movieDBContext;

        public ReviewRepository(MovieDBContext movieDBContext)
        {
            this.movieDBContext = movieDBContext;
        }
        public async Task<Review> AddReview(Review review)
        {
            var result = await movieDBContext.Review.AddAsync(review);
            await movieDBContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<IEnumerable<Review>> GetReviewsByMovieId(int movieId)
        {
            return await movieDBContext.Review
                                     .Where(e => e.MovieId == movieId).ToListAsync();
        }
    }
}
