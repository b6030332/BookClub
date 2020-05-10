using BookClub.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookClub.Data.IDAO
{
    public interface IReviewDAO
    {
        Review GetReviewByBook(int id);
        void AddReview(Review review);
        void DeleteReview(int id, Review review);
    }
}
