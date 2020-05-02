using BookClub.Data.IDAO;
using BookClub.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookClub.Data.DAO
{
    public class ReviewDAO : IReviewDAO
    {
        private ApplicationDbContext _context;
        public ReviewDAO()
        {
            _context = new ApplicationDbContext();
        }

        public Review GetReviewByBook(int id)
        {
            return _context.Review.Find(id);
        }
    }
}
