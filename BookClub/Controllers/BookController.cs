using BookClub.Data;
using BookClub.Data.IDAO;
using BookClub.Data.Models;
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
        
         public ActionResult GetDiscussionsbyBook(int id)
         {
          
            IList<Discussion> discussions = _bookService.GetDiscussionsByBook(id);
            return View("GetDiscussionsByBook", discussions);
         }
        public ActionResult Index(string searching)
        {
            return View(_context.Book.Where(b => b.Title.Contains(searching) || searching == null).ToList());
        } 
    }
}
    
