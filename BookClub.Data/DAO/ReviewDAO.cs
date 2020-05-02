using BookClub.Data.IDAO;
using BookClub.Data.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BookClub.Data.DAO
{
    public class ReviewDAO : IReviewDAO
    {
        private ApplicationDbContext _context;
        public ReviewDAO()
        {
            _context = new ApplicationDbContext();
        }

        public void AddReview(Review review)
        {
            var currentBook = _context.Book.FirstOrDefault(b => b.Id == review.Id);

            string currentUserId = HttpContext.Current.User.Identity.GetUserId();
            ApplicationUser currentUser = _context.Users.FirstOrDefault
                (x => x.Id == currentUserId);

            review.User = currentUser;
            review.Book = currentBook;

            _context.Review.Add(review);
            _context.SaveChanges();
            
        }

        public Review GetReviewByBook(int id)
        {
            return _context.Review.Find(id);
        }
    }
}
