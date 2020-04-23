using BookClub.Data.IDAO;
using BookClub.Data.Models;
using BookClub.Service.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookClub.Controllers
{
    public class BookController : Controller
    {
        private IBookDAO _bookService;
        public BookController()
        {
            _bookService = new BookService();
        }

        public ActionResult GetAllBooks()
        {
            IList<Book> books = _bookService.GetAllBooks();
            return View("GetAllBooks", books);
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

        }
    }
