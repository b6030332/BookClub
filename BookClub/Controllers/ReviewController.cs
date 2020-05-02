using BookClub.Data.IDAO;
using BookClub.Data.Models;
using BookClub.Models.Book;
using BookClub.Models.JointViews;
using BookClub.Models.Review;
using BookClub.Service.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookClub.Controllers
{
    public class ReviewController : Controller
    {
        private readonly IReviewDAO _reviewService;
        private readonly IBookDAO _bookService;
        public ReviewController()
        {
            _reviewService = new ReviewService();
            _bookService = new BookService();
        }
        // GET: Review
        public ActionResult GetReviewByBook(int id)
        {
            var book = _bookService.GetBookId(id);

            var reviews = book.Reviews;

            var listofReviews = reviews.Select(review => new ReviewViewModel
            {
                Id = review.Id,
                BookId = review.BookId,
                ReviewContent = review.ReviewContent,
                DateCreated = DateTime.Now,
                Rating = review.Rating,
            });

            return View(listofReviews);

            // var model = new BookReviewModel
            //{
            //    Reviews = listofReviews,
            // Book = BuildNewBook(book)
            /// };

            //  return View(model);
            // }
            //private NewBook BuildNewBook(Book book)
            //{
            //    return new NewBook
            //    {
            //        Id = book.Id,
            //        Title = book.Title,
            //        Blurb = book.Blurb,
            //        Genre = book.Genre.Name,
            //        BookImage = book.Image
            //    };
            //}
        }
    }
}