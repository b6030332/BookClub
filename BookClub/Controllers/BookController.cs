using BookClub.Data;
using BookClub.Data.IDAO;
using BookClub.Data.Models;
using BookClub.Models;
using BookClub.Models.Book;
using BookClub.Models.Discussion;
using BookClub.Service.Service;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace BookClub.Controllers
{
    public class BookController : Controller
    {
        private ApplicationDbContext _context;
        private IBookDAO _bookService;
        public BookController()
        {
            _context = new ApplicationDbContext();
            _bookService = new BookService();
        }
        
        public ActionResult GetAllBooks(string option, string search)
        {
            if (option == "Genre")
            {
                return View(_context.Book.Where(b => b.Genre.Name == search || search == null).ToList());
            }
            else if (option == "Author")
            {
                return View(_context.Book.Where(b => b.Author.Name == search || search == null).ToList());
            }
            else
            {
                return View(_context.Book.Where(b => b.Title.StartsWith(search) || search == null).ToList());
            }
        }
        public ActionResult GetBookId(int id)
        {
            Book books = _bookService.GetBookId(id);
            return View("GetBookId", books);
        }
        
        // public ActionResult GetDiscussionsbyBook(int id)
        // {
          
            //IList<Discussion> discussions = _bookService.GetDiscussionsByBook(id);
           // return View("GetDiscussionsByBook", discussions);
         //}
        public ActionResult Index(string searching)
        {
            return View(_context.Book.Where(b => b.Title.Contains(searching) || searching == null).ToList());
        }
        public ActionResult GetB(int id)
        {
            var book = _bookService.GetBookId(id);

            var discussions = book.Discussions;

            var listofDiscussions = discussions.Select(discussion => new ListofDiscussions
            {
                Id = discussion.Id,
                AuthorId = discussion.ApplicationUser.Id,
                Title = discussion.Title,
                Content = discussion.Description,
                DatePosted = discussion.Created.ToString(),
                BookId = discussion.Books.Id,
                BookName = discussion.Books.Title,
                BookBlurb = discussion.Books.Blurb,
                BookImage = discussion.Books.Image

            });

            var model = new BookDiscussionModel
            {
                Discussions = listofDiscussions,
                Book = BuildNewBook(book)
            };

            return View(model);
        }

        private NewBook BuildNewBook(Book book)
        {
            return new NewBook
            {
                Id = book.Id,
                Title = book.Title,
                Blurb = book.Blurb,
                Genre = book.Genre.Name,
                BookImage = book.Image

            };
        }
        
    }
}

    
