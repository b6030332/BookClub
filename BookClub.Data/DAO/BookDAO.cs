using BookClub.Data.IDAO;
using BookClub.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookClub.Data.DAO
{
    public class BookDAO : IBookDAO
    {
        private ApplicationDbContext _context;
        public BookDAO()
        {
            _context = new ApplicationDbContext();
        }

        public IList<Book> GetAllBooks()
        {
            return _context.Book.ToList();
        }

        public Book GetBookId(int id)
        {
            return _context.Book.Find(id);
        }

        public IList<Discussion> GetDiscussionsByBook(int id)
        {
            Book book = _context.Book.Find(id);
            return book.Discussions.ToList();
        }
    }
}
