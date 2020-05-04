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
    public class FavouritesController : Controller
    {
        private readonly IBookDAO _bookService;
        public FavouritesController()
        {
            _bookService = new BookService();
        }
            
       
    }
}