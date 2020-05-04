using BookClub.Data.IDAO;
using BookClub.Data.Models;
using BookClub.Models.Favourites;
using BookClub.Service.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookClub.Controllers
{
    public class FavouritesController : Controller
    {
        private readonly IBookDAO _bookService;
        public FavouritesController()
        {
            _bookService = new BookService();
        }
            
        // GET: Favourites
        public ActionResult Index()
        {
            return View();
        }
        //public ActionResult AddBookToFavourites(int bookId)
        //{
        //    List<FavouriteBooks> favourites = new List<FavouriteBooks>();
        //    Book book = _bookService.GetBookId(bookId);
        //    favourites.Add(new FavouriteBooks()
        //    { 
        //        Book=book,

        //    });

        //}
    }
}