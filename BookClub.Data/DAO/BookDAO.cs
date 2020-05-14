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

        public void AddBook(Book book)
        {
            _context.Book.Add(book);
            _context.SaveChanges(); 
        }

        public void DeleteBook(Book book)
        {
            //find first instance of book to delete
            var deleteBook = _context.Book.FirstOrDefault(b => b.Id == book.Id);

            //if not null, delete post
            if (deleteBook != null)
            {
                //call remove & save changes on the post that is found above
                _context.Book.Remove(deleteBook);
                _context.SaveChanges();
            }
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

        public void UpdateBook(Book book)
        {
            
            Book _book = GetBookId(book.Id);
            _book.Image = book.Image;
            _book.Title = book.Title;
            _book.Year = book.Year;
            _book.Publisher = book.Publisher;
            _book.Format = book.Format;
            _book.Price = book.Price;
            _book.Blurb = book.Blurb;
            _book.ISBN = book.ISBN;
            _book.GenreId = book.GenreId;
            _book.AuthorId = book.AuthorId;
            _context.SaveChanges();
        }
    }
}
