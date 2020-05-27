using BookClub.Data.IDAO;
using BookClub.Data.Models;
using BookClub.Service.Service;
using BookClub.ViewModels.Discussion;
using System;
using System.Web.Mvc;

namespace BookClub.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly IPostDAO _postService;
        private readonly IReplyDAO _replyService;
        private readonly IDiscussionDAO _discussionService;
        private readonly IBookDAO _bookService;
        private readonly IGenreDAO _genreService;
        private readonly IAuthorDAO _authorService;

        
        public AdminController()
        {
            _postService = new PostService();
            _discussionService = new DiscussionService();
            _bookService = new BookService();
            _replyService = new ReplyService();
            _genreService = new GenreService();
            _authorService = new AuthorService();
        }

       
        [HttpGet]
        public ActionResult AddDiscussion()
        {
            ViewBag.BookId = new SelectList(_bookService.GetAllBooks(), "Id", "Title");
            
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddDiscussion(Discussion discussion)
        {
            
            try
            {
                discussion.Created = DateTime.Now;

                _discussionService.AddDiscussion(discussion);


                return RedirectToAction("GetAllDiscussions", "Discussion", discussion);
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult AddBook()
        {
            ViewBag.GenreId = new SelectList(_genreService.GetAllGenres(), "Id", "Name");
            ViewBag.AuthorId = new SelectList(_authorService.GetAllAuthors(), "Id", "Name");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddBook(Book book)
        {
            try
            {

                _bookService.AddBook(book);


                return RedirectToAction("GetAllBooks", "Book", book);
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult UpdateBook(int id)
        {
            Book book = _bookService.GetBookId(id);
            ViewBag.AuthorId = new SelectList(_authorService.GetAllAuthors(), "ID", "Name", book.AuthorId);
            ViewBag.GenreId = new SelectList(_genreService.GetAllGenres(), "ID", "Name", book.GenreId);

            return View(book);
        }
        [HttpPost]
        public ActionResult UpdateBook(int id, Book book)
        {
            try
            {
                _bookService.UpdateBook(book);
                return RedirectToAction("GetBookId", "Book", new { id = book.Id });
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult UpdateDiscussion(int id)
        {
            Discussion discussion = _discussionService.GetDiscussionID(id);
            return View(discussion);
        }
        [HttpPost]
        public ActionResult UpdateDiscussion(int id, Discussion discussion)
        {
            try
            {
                _discussionService.UpdateDiscussion(discussion);
                return RedirectToAction("GetAllDiscussions", "Discussion", new { id = discussion.Id });
            }
            catch
            {
                return View();
            }
        }
        [HttpGet]
        public ActionResult DeleteDiscussion(int id)
        {

            return View(_discussionService.GetDiscussionID(id));
        }
        [HttpPost]
        public ActionResult DeleteDiscussion(int id, Discussion discussion)
        {

            Discussion _discussion = _discussionService.GetDiscussionID(id);

            _discussionService.DeleteDiscussion(discussion);

            return RedirectToAction("GetAllDiscussions", "Discussion", new { id = discussion.Id });

        }

        [HttpGet]
        public ActionResult DeleteBook(int id)
        {

            return View(_bookService.GetBookId(id));
        }
        [HttpPost]
        public ActionResult DeleteBook(int id, Book book)
        {

            Book _book = _bookService.GetBookId(id);

            _bookService.DeleteBook(book);

            return RedirectToAction("GetAllBooks", "Book", new { id = book.Id });

        }
    }

}