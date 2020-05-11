﻿using BookClub.Data;
using BookClub.Data.IDAO;
using BookClub.Data.Models;
using BookClub.Models;
using BookClub.Models.Book;
using BookClub.Models.Discussion;
using BookClub.Service.Service;
using BookClub.ViewModels.Book;
using BookClub.ViewModels.JointViewModels;
using System.Linq;
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

            BookDetailViewModel bookDetail = new BookDetailViewModel()
            {
                Id = books.Id,
                BookTitle = books.Title,
                BookImage = books.Image,
                ISBN = books.ISBN,
                Price = books.Price,
                Publisher = books.Publisher,
                Format = books.Format,
                Blurb = books.Blurb,
                Year = books.Year
            };

            return View(bookDetail);
        }
        
        
        public ActionResult GetB(int id)
        {
            var book = _bookService.GetBookId(id);

            var discussions = book.Discussions;

            var listofDiscussions = discussions.Select(discussion => new ListofDiscussions
            {
                Id = discussion.Id,
                AuthorId = discussion.ApplicationUser.Id,
                AuthorName = discussion.ApplicationUser.UserName,
                Title = discussion.Title,
                Content = discussion.Description,
                DatePosted = discussion.Created.ToString(),
                BookId = discussion.Books.Id,
                BookName = discussion.Books.Title,
                BookBlurb = discussion.Books.Blurb
                //BookImage = discussion.Books.Image

            });

            var model = new BookDiscussionViewModel
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

    
