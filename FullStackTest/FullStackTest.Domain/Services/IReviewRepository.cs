using FullStackTest.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullStackTest.Domain.Services
{
    public interface IReviewRepository
    {
        Task<IEnumerable<Review>> GetReviewsByMovieId(int movieId);
        Task<Review> AddReview(Review review);
    }
}
