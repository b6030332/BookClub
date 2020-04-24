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
    public class AuthorController : Controller
    {
        private IAuthorDAO _authorService;
        public AuthorController()
        {
            _authorService = new AuthorService();
        }
        public ActionResult GetAuthor(int id)
        {
            Author author = _authorService.GetAuthor(id);
            return View("GetAuthor", author);
        }
        public ActionResult GetBooksbyAuthor(int id)
        {
            IEnumerable<Book> books = _authorService.GetBooksByAuthor(id);
            return View("GetBooksbyAuthor", books);
        }

        // GET: Author
        public ActionResult Index()
        {
            return View();
        }
    }
}