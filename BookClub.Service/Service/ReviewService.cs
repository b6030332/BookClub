using BookClub.Data.DAO;
using BookClub.Data.IDAO;
using BookClub.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookClub.Service.Service
{
    public class ReviewService : IReviewDAO
    {
        private IReviewDAO _dao;
        public ReviewService()
        {
            _dao = new ReviewDAO();
        }

        public void AddReview(Review review)
        {
            _dao.AddReview(review);
        }

        public void DeleteReview(int id, Review review)
        {
            _dao.DeleteReview(id, review);
        }

        public Review GetReviewByBook(int id)
        {
            return _dao.GetReviewByBook(id);
        }
    }
}
