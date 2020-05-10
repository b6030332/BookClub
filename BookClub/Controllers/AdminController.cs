using BookClub.Data.IDAO;
using BookClub.Data.Models;
using BookClub.Service.Service;
using BookClub.ViewModels.Discussion;
using System;
using System.Web.Mvc;

namespace BookClub.Controllers
{
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
        public ActionResult AddDiscussion(int id)
        {
            //Find the id of book we're posting discussion in 
            var book = _bookService.GetBookId(id);
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddDiscussion(AddDiscussionViewModel model, Book book)
        {
            //Map the new Discussion values for NewDiscussion model to be pushed into database

            if (ModelState.IsValid)

            {
                Discussion discussion = new Discussion();
                discussion.Title = model.DiscussionTitle;
                discussion.Description = model.DiscussionContent;
                discussion.Created = DateTime.Now;

                //logic for adding discussion with user and book id is processed in the DiscussionDAO 

                _discussionService.AddDiscussion(discussion, book);

                return RedirectToAction("GetB", "Book", new { id = discussion.BookId });
            }

            return View(model);
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
    }
}