using BookClub.Data.IDAO;
using BookClub.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookClub.Data.DAO
{
    public class AuthorDAO : IAuthorDAO
    {
        private ApplicationDbContext _context;
        public AuthorDAO()
        {
            _context = new ApplicationDbContext();
        }

        public IList<Author> GetAllAuthors()
        {
            return _context.Author.ToList();
        }

        public Author GetAuthor(int id)
        {
            return _context.Author.Find(id);
        }

        public IEnumerable<Book> GetBooksByAuthor(int id)
        {
            Author author = _context.Author.Find(id);
            return author.Books.ToList();
        }
    }
}
