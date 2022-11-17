using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullStackTest.Data.Models
{
    public class ReviewValidator : AbstractValidator<Review>
    {
        public ReviewValidator()
        {
            RuleFor(x => x.Review1).NotEmpty();
            RuleFor(x => x.MovieId).NotNull();
            RuleFor(x=>x.Rating).NotEmpty().GreaterThan(5).LessThan(0);
        }
    }
}
